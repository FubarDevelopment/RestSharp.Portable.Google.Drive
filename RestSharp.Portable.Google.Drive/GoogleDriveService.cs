﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

using JetBrains.Annotations;

using RestSharp.Portable.Google.Drive.Model;

namespace RestSharp.Portable.Google.Drive
{
    /// <summary>
    /// A class to access the Google Drive API V2
    /// </summary>
    public sealed class GoogleDriveService : IDisposable
    {
        private static readonly ISerializer RestSerializer = new ConservativeJsonSerializer();

        private static readonly string DriveApiPath = "drive/v2/";

        private static readonly string DriveUploadApiPath = "upload/" + DriveApiPath;

        private readonly IRequestFactory _restClientFactory;

        private readonly IRestClient _restClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="GoogleDriveService"/> class.
        /// </summary>
        /// <param name="factory">The factory to create the <see cref="IRestClient"/> implementation and <see cref="HttpWebRequest"/> instance.</param>
        public GoogleDriveService([NotNull] IRequestFactory factory)
        {
            _restClientFactory = factory;
            _restClient = CreateClient();
        }

        /// <summary>
        /// The <code>about</code> request to get some basic information about the
        /// Google Drive service to use.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns>The basic Google Drive information</returns>
        [NotNull]
        public async Task<About> AboutAsync(CancellationToken cancellationToken)
        {
            var aboutRequest = new RestRequest("about");
            var aboutResponse = await _restClient.Execute<About>(aboutRequest, cancellationToken);
            return aboutResponse.Data;
        }

        /// <summary>
        /// Delete the given <paramref name="item"/>
        /// </summary>
        /// <param name="item">The <see cref="File"/> to delete</param>
        /// <param name="cancellationToken"></param>
        /// <returns>The <see cref="Task"/></returns>
        public async Task DeleteAsync([NotNull] File item, CancellationToken cancellationToken)
        {
            var request = CreateRequest($"files/{item.Id.Escape()}", Method.DELETE);
            await _restClient.Execute(request, cancellationToken);
        }

        /// <summary>
        /// Move the <paramref name="item"/> into the trash
        /// </summary>
        /// <param name="item">The <see cref="File"/> to move into the trash</param>
        /// <param name="cancellationToken"></param>
        /// <returns>The modified <paramref name="item"/></returns>
        [NotNull]
        public async Task<File> TrashAsync([NotNull] File item, CancellationToken cancellationToken)
        {
            var request = CreateRequest($"files/{item.Id.Escape()}/trash", Method.POST);
            request.AddHeader("Content-Length", 0);
            return (await _restClient.Execute<File>(request, cancellationToken)).Data;
        }

        /// <summary>
        /// Remove the <paramref name="item"/> from the trash
        /// </summary>
        /// <param name="item">The <see cref="File"/> to remove from the trash</param>
        /// <param name="cancellationToken"></param>
        /// <returns>The modified <paramref name="item"/></returns>
        [NotNull]
        public async Task<File> UntrashAsync([NotNull] File item, CancellationToken cancellationToken)
        {
            var request = CreateRequest($"files/{item.Id.Escape()}/untrash", Method.POST);
            return (await _restClient.Execute<File>(request, cancellationToken)).Data;
        }

        /// <summary>
        /// Changes the parent of the <paramref name="item"/> and (optionally) its name.
        /// </summary>
        /// <param name="item">The <see cref="File"/> to change the parent for</param>
        /// <param name="sourceFolderId">The original parent of the <paramref name="item"/></param>
        /// <param name="destinationFolder">The target parent of the <paramref name="item"/></param>
        /// <param name="newTitle">The new <paramref name="item"/> name (title)</param>
        /// <param name="cancellationToken"></param>
        /// <returns>The modified <paramref name="item"/></returns>
        [NotNull]
        public async Task<File> MoveAsync([NotNull] File item, [NotNull] string sourceFolderId, [NotNull] File destinationFolder, [CanBeNull] string newTitle, CancellationToken cancellationToken)
        {
            var request = CreateRequest($"files/{item.Id.Escape()}", Method.PATCH);
            request.AddQueryParameter("addParents", destinationFolder.Id);
            request.AddQueryParameter("removeParents", sourceFolderId);
            if (!string.IsNullOrEmpty(newTitle))
            {
                request.AddBody(
                    new
                    {
                        title = newTitle,
                    });
            }
            return (await _restClient.Execute<File>(request, cancellationToken)).Data;
        }

        /// <summary>
        /// Get the download URL for a <see cref="File"/>
        /// </summary>
        /// <param name="fileId">The id of the <see cref="File"/> to download</param>
        /// <param name="cancellationToken"></param>
        /// <returns>The download URL</returns>
        [NotNull]
        public async Task<string> GetDownloadUrlAsync([NotNull] string fileId, CancellationToken cancellationToken)
        {
            var info = await GetFileAsync(fileId, cancellationToken);
            return GetDownloadUrl(info);
        }

        /// <summary>
        /// Get the download URL for a <see cref="File"/>
        /// </summary>
        /// <param name="info"></param>
        /// <returns>The download URL</returns>
        [NotNull]
        public string GetDownloadUrl([NotNull] File info)
        {
            if (string.IsNullOrEmpty(info.DownloadUrl))
            {
                var request = CreateRequest($"files/{info.Id.Escape()}", Method.GET);
                request.AddQueryParameter("alt", "media");
                return _restClient.BuildUri(request).ToString();
            }
            return info.DownloadUrl;
        }

        /// <summary>
        /// Get a <see cref="HttpWebResponse"/> to download a <see cref="File"/>
        /// </summary>
        /// <param name="file">The <see cref="File"/> to download</param>
        /// <param name="range">The <see cref="HttpRange"/> to download</param>
        /// <param name="cancellationToken"></param>
        /// <returns>The <see cref="HttpWebResponse"/> used to download the file</returns>
        public async Task<HttpWebResponse> GetDownloadResponseAsync(File file, HttpRange range, CancellationToken cancellationToken)
        {
            var downloadUrl = GetDownloadUrl(file);
            var request = await _restClientFactory.CreateWebRequest(new Uri(downloadUrl));
            if (range != null)
                request.Headers[HttpRequestHeader.Range] = range.ToString();
            var response = (HttpWebResponse)await Task.Factory.FromAsync<WebResponse>(request.BeginGetResponse, request.EndGetResponse, null);
            return response;
        }

        /// <summary>
        /// Upload a file
        /// </summary>
        /// <remarks>
        /// The mime type is guessed using the given <paramref name="name"/>.
        /// </remarks>
        /// <param name="folderId">The target <see cref="File"/> (folder) ID to upload to</param>
        /// <param name="name">The new file name</param>
        /// <param name="input">The data to upload</param>
        /// <param name="cancellationToken"></param>
        /// <returns>The <see cref="Task"/></returns>
        public Task UploadAsync([NotNull] string folderId, [NotNull] string name, [NotNull] Stream input, CancellationToken cancellationToken)
        {
            var mimeType = MimeTypes.GetMimeType(name);
            return UploadAsync(folderId, name, input, mimeType, cancellationToken);
        }

        /// <summary>
        /// Upload a file
        /// </summary>
        /// <param name="folderId">The target <see cref="File"/> (folder) ID to upload to</param>
        /// <param name="name">The new file name</param>
        /// <param name="input">The data to upload</param>
        /// <param name="mimeType">The mime type of the file to upload</param>
        /// <param name="cancellationToken"></param>
        /// <returns>The <see cref="Task"/></returns>
        public async Task UploadAsync([NotNull] string folderId, [NotNull] string name, [NotNull] Stream input, [NotNull] string mimeType, CancellationToken cancellationToken)
        {
            using (var uploadClient = CreateClient())
            {
                var length = input.Length;

                var newItem = new File()
                {
                    Title = name,
                    MimeType = mimeType,
                    Parents = new List<ParentReference>
                    {
                        new ParentReference()
                        {
                            Id = folderId
                        }
                    },
                };

                var requestStartResumableSession = CreateRequest($"/{DriveUploadApiPath}files", Method.POST);
                requestStartResumableSession.AddQueryParameter("uploadType", "resumable");
                requestStartResumableSession.AddHeader("X-Upload-Content-Type", mimeType);
                requestStartResumableSession.AddHeader("X-Upload-Content-Length", length);
                requestStartResumableSession.AddBody(newItem);
                var responseStartResumableSession = await uploadClient.Execute(requestStartResumableSession, cancellationToken);
                var sessionUri = responseStartResumableSession.ResponseUri.OriginalString;

                uploadClient.IgnoreResponseStatusCode = true;
                int blockSize = 262144; // Info from Google PUT error message
                var buffer = new byte[blockSize];
                byte[] temp = null;
                int size;
                for (long i = 0; i != length; i += size)
                {
                    size = (int)Math.Min(length, blockSize);

                    var readSize = input.Read(buffer, 0, size);
                    if (readSize == 0)
                        throw new InvalidOperationException($"Failed to read {size} bytes from position {i}");

                    size = readSize;
                    var requestRange = new HttpRange("bytes", new HttpRangeItem(i, i + size - 1));

                    if (temp == null || temp.Length != size)
                        temp = new byte[size];
                    Array.Copy(buffer, temp, size);
                    var requestUploadChunk = CreateRequest(sessionUri, Method.PUT);
                    //requestUploadChunk.AddHeader("Content-Length", size);
                    //requestUploadChunk.AddHeader("Content-Type", mimeType);
                    requestUploadChunk.AddHeader("Content-Range", requestRange.ToString(requestRange.RangeItems.Single(), length));
                    requestUploadChunk.AddParameter(string.Empty, temp, ParameterType.RequestBody, mimeType);

                    var responseUploadChunk = await uploadClient.Execute(requestUploadChunk, cancellationToken);
                    if (!responseUploadChunk.IsSuccess && responseUploadChunk.StatusCode != (HttpStatusCode)308)
                        throw new WebException(responseUploadChunk.StatusDescription, WebExceptionStatus.UnknownError);
                    IEnumerable<string> rangeValue;
                    if (responseUploadChunk.Headers.TryGetValues("Range", out rangeValue))
                    {
                        size = (int)HttpRange.Parse(rangeValue.Single()).Normalize(length).Sum(x => x.Length);
                    }
                }
            }
        }

        /// <summary>
        /// Get a <see cref="File"/> (file or folder) metadata
        /// </summary>
        /// <param name="fileId">The ID of the item to get the metadata for</param>
        /// <param name="cancellationToken"></param>
        /// <returns>The metadata</returns>
        [NotNull]
        public async Task<File> GetFileAsync([NotNull] string fileId, CancellationToken cancellationToken)
        {
            var request = CreateRequest($"files/{fileId.Escape()}");
            return (await _restClient.Execute<File>(request, cancellationToken)).Data;
        }

        /// <summary>
        /// Gets all children of a <see cref="File"/> (<paramref name="folder"/>)
        /// </summary>
        /// <param name="folder">The <see cref="File"/> to get its children from</param>
        /// <param name="cancellationToken"></param>
        /// <returns>The children of <paramref name="folder"/></returns>
        [NotNull, ItemNotNull]
        public async Task<IReadOnlyList<File>> GetChildrenAsync([NotNull] File folder, CancellationToken cancellationToken)
        {
            var request = CreateRequest("files");
            request.AddParameter("q", $"'{folder.Id.Escape()}' in parents");
            var response = await _restClient.Execute<ResourceList<File>>(request, cancellationToken);
            return response.Data.Items;
        }

        /// <summary>
        /// Get all subfolders of the <paramref name="folder"/>
        /// </summary>
        /// <param name="folder">The <see cref="File"/> (folder) to get the subfolders from</param>
        /// <param name="cancellationToken"></param>
        /// <returns>The list of <see cref="File"/> (subfolders) for the given <paramref name="folder"/></returns>
        [NotNull, ItemNotNull]
        public async Task<IReadOnlyList<File>> GetDirectoriesAsync([NotNull] File folder, CancellationToken cancellationToken)
        {
            var request = CreateRequest("files");
            request.AddParameter("q", $"mimeType='{FileExtensions.DirectoryMimeType}' and '{folder.Id.Escape()}' in parents");
            var response = await _restClient.Execute<ResourceList<File>>(request, cancellationToken);
            return response.Data.Items;
        }

        /// <summary>
        /// Get all files in a given <paramref name="folder"/>
        /// </summary>
        /// <param name="folder">The <see cref="File"/> (folder) to get its files from</param>
        /// <param name="cancellationToken"></param>
        /// <returns>The list of <see cref="File"/> (files) for the given <paramref name="folder"/></returns>
        [NotNull, ItemNotNull]
        public async Task<IReadOnlyList<File>> GetFilesAsync([NotNull] File folder, CancellationToken cancellationToken)
        {
            var request = CreateRequest("files");
            request.AddParameter("q", $"(not (mimeType='{FileExtensions.DirectoryMimeType}')) and '{folder.Id.Escape()}' in parents");
            var response = await _restClient.Execute<ResourceList<File>>(request, cancellationToken);
            return response.Data.Items;
        }

        /// <summary>
        /// Create a new subfolder
        /// </summary>
        /// <param name="folder">The <see cref="File"/> (folder) to create the subfolder in</param>
        /// <param name="name">The new subfolder name</param>
        /// <param name="cancellationToken"></param>
        /// <returns>The new subfolder metadata</returns>
        [NotNull]
        public async Task<File> CreateDirectoryAsync([NotNull] File folder, [NotNull] string name, CancellationToken cancellationToken)
        {
            var newItem = new File()
            {
                Title = name,
                MimeType = FileExtensions.DirectoryMimeType,
                Parents = new List<ParentReference>
                        {
                            new ParentReference()
                            {
                                Id = folder.Id
                            }
                        },
            };
            var createFolderRequest = CreateRequest("files", Method.POST);
            createFolderRequest.AddBody(newItem);
            return (await _restClient.Execute<File>(createFolderRequest, cancellationToken)).Data;
        }

        /// <summary>
        /// Get or create the subfolder the <paramref name="folder"/> and <paramref name="path"/> are pointing to
        /// </summary>
        /// <param name="folder">The base <see cref="File"/> (folder)</param>
        /// <param name="path">The path to the subfolder (divided by a /)</param>
        /// <param name="cancellationToken"></param>
        /// <returns>The metadata of the found or created subfolder</returns>
        [NotNull]
        public async Task<File> GetOrCreateDirectoryAsync([NotNull] File folder, [NotNull] string path, CancellationToken cancellationToken)
        {
            var current = folder;
            var nameComparer = StringComparer.OrdinalIgnoreCase;
            var folderParts = path.Split(new[]
            {
                '/', '\\'
            }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var folderPart in folderParts)
            {
                var foldersRequest = CreateRequest("files");
                foldersRequest.AddParameter("q", $"mimeType='{FileExtensions.DirectoryMimeType}' and '{current.Id.Escape()}' in parents and title='{folderPart.Escape()}'");
                var response = await _restClient.Execute<ResourceList<File>>(foldersRequest, cancellationToken);
                var subFolder =
                    response.Data.Items.FirstOrDefault(x => nameComparer.Equals(x.Title, folderPart))
                    ?? await CreateDirectoryAsync(current, folderPart, cancellationToken);
                current = subFolder;
            }
            return current;
        }

        [NotNull]
        private IRestClient CreateClient()
        {
            var client = _restClientFactory.CreateRestClient(new Uri($"https://www.googleapis.com/{DriveApiPath}"));
            return client;
        }

        [NotNull]
        private IRestRequest CreateRequest([NotNull] string resource)
        {
            return new RestRequest(resource)
            {
                Serializer = RestSerializer,
            };
        }

        [NotNull]
        private IRestRequest CreateRequest([NotNull] string resource, Method method)
        {
            return new RestRequest(resource, method)
            {
                Serializer = RestSerializer,
            };
        }

        #region IDisposable Support
        private bool _disposedValue; // Dient zur Erkennung redundanter Aufrufe.

        void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    _restClient.Dispose();
                }
                _disposedValue = true;
            }
        }

        /// <summary>
        /// Dispose all resources
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
        }
        #endregion
    }
}