using System;
using System.Collections.Generic;

namespace RestSharp.Portable.Google.Drive.Model
{
    /// <summary>
    /// The metadata for a file.
    /// </summary>
    public class File
    {
        /// <summary>
        /// The type of file. This is always <code>drive#file</code>.
        /// </summary>
        public string Kind { get; set; }

        /// <summary>
        /// The ID of the file.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// ETag of the file.
        /// </summary>
        public string Etag { get; set; }

        /// <summary>
        /// A link back to this file.
        /// </summary>
        public string SelfLink { get; set; }

        /// <summary>
        /// A link for downloading the content of the file in a browser using cookie based authentication.
        /// </summary>
        /// <remarks>
        /// In cases where the content is shared publicly, the content can be downloaded without any credentials.
        /// </remarks>
        public string WebContentLink { get; set; }

        /// <summary>
        /// A link only available on public folders for viewing their static web assets (HTML, CSS, JS, etc)
        /// via Google Drive's Website Hosting.
        /// </summary>
        public string WebViewLink { get; set; }

        /// <summary>
        /// A link for opening the file in a relevant Google editor or viewer.
        /// </summary>
        public string AlternateLink { get; set; }

        /// <summary>
        /// A link for embedding the file.
        /// </summary>
        public string EmbedLink { get; set; }

        /// <summary>
        /// A map of the id of each of the user's apps to a link to open this file with that app.
        /// </summary>
        /// <remarks>
        /// Only populated when the drive.apps.readonly scope is used.
        /// </remarks>
        public IDictionary<string, string> OpenWithLinks { get; set; }

        /// <summary>
        /// A link to open this file with the user's default app for this file.
        /// </summary>
        /// <remarks>
        /// Only populated when the drive.apps.readonly scope is used.
        /// </remarks>
        public string DefaultOpenWithLinks { get; set; }

        /// <summary>
        /// A link to the file's icon.
        /// </summary>
        public string IconLink { get; set; }

        /// <summary>
        /// A short-lived link to the file's thumbnail.
        /// </summary>
        /// <remarks>
        /// Typically lasts on the order of hours.
        /// </remarks>
        public string ThumbnailLink { get; set; }

        /// <summary>
        /// Thumbnail for the file.
        /// </summary>
        /// <remarks>
        /// Only accepted on upload and for files that are not already thumbnailed by Google.
        /// </remarks>
        public Thumbnail Thumbnail { get; set; }

        /// <summary>
        /// The title of the file. Used to identify file or folder name.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// The MIME type of the file.
        /// </summary>
        /// <remarks>
        /// This is only mutable on update when uploading new content. This field can be left blank,
        /// and the mimetype will be determined from the uploaded content's MIME type.
        /// </remarks>
        public string MimeType { get; set; }

        /// <summary>
        /// A short description of the file.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// A group of labels for the file.
        /// </summary>
        public FileLabels Labels { get; set; }

        /// <summary>
        /// Create time for this file
        /// </summary>
        public DateTimeOffset? CreatedDate { get; set; }

        /// <summary>
        /// Last time this file was modified by anyone
        /// </summary>
        /// <remarks>
        /// This is only mutable on update when the setModifiedDate parameter is set.
        /// </remarks>
        public DateTimeOffset? ModifiedDate { get; set; }

        /// <summary>
        /// Last time this file was modified by the user.
        /// </summary>
        /// <remarks>
        /// Note that setting <see cref="ModifiedDate"/> will also update the 
        /// <see cref="ModifiedByMeDate"/> date for the user which set the date.
        /// </remarks>
        public DateTimeOffset? ModifiedByMeDate { get; set; }

        /// <summary>
        /// Last time this file was viewed by the user.
        /// </summary>
        public DateTimeOffset? LastViewedByMeDate { get; set; }

        /// <summary>
        /// Time this file was explicitly marked viewed by the user.
        /// </summary>
        public DateTimeOffset? MarkedViewedByMeDate { get; set; }

        /// <summary>
        /// Time at which this file was shared with the user.
        /// </summary>
        public DateTimeOffset? SharedWithMeDate { get; set; }

        /// <summary>
        /// A monotonically increasing version number for the file.
        /// </summary>
        /// <remarks>
        /// This reflects every change made to the file on the server,
        /// even those not visible to the requesting user.
        /// </remarks>
        public long? Version { get; set; }

        /// <summary>
        /// User that shared the item with the current user, if available.
        /// </summary>
        public User SharingUser { get; set; }

        /// <summary>
        /// Collection of parent folders which contain this file.
        /// </summary>
        /// <remarks>
        /// Setting this field will put the file in all of the provided folders.
        /// On insert, if no folders are provided, the file will be placed in the
        /// default root folder.
        /// </remarks>
        public IList<ParentReference> Parents { get; set; }

        /// <summary>
        /// The download URL
        /// </summary>
        public string DownloadUrl { get; set; }

        /// <summary>
        /// Links for exporting Google Docs to specific formats.
        /// </summary>
        /// <remarks>
        /// A mapping from export format to URL
        /// </remarks>
        public IDictionary<string, string> ExportLinks { get; set; }

        /// <summary>
        /// Indexable text attributes for the file.
        /// </summary>
        /// <remarks>
        /// This property can only be written, and is not returned by <code>files.get</code>.
        /// </remarks>
        public TextData IndexableText { get; set; }

        /// <summary>
        /// The permissions for the authenticated user on this file.
        /// </summary>
        public Permission UserPermissions { get; set; }

        /// <summary>
        /// The list of permissions for users with access to this file.
        /// </summary>
        public IList<Permission> Permissions { get; set; }

        /// <summary>
        /// The original filename if the file was uploaded manually, or the original title if the file was inserted through the API.
        /// </summary>
        /// <remarks>
        /// Note that renames of the title will not change the original filename.
        /// This field is only populated for files with content stored in Drive;
        /// it is not populated for Google Docs or shortcut files.
        /// </remarks>
        public string OriginalFilename { get; set; }

        /// <summary>
        /// The final component of fullFileExtension with trailing text that does not appear
        /// to be part of the extension removed.
        /// </summary>
        /// <remarks>
        /// This field is only populated for files with content stored in Drive;
        /// it is not populated for Google Docs or shortcut files.
        /// </remarks>
        public string FileExtension { get; set; }

        /// <summary>
        /// The full file extension; extracted from the title.
        /// </summary>
        /// <remarks>
        /// May contain multiple concatenated extensions, such as "tar.gz".
        /// Removing an extension from the title does not clear this field;
        /// however, changing the extension on the title does update this field.
        /// This field is only populated for files with content stored in Drive;
        /// it is not populated for Google Docs or shortcut files.
        /// </remarks>
        public string FullFileExtension { get; set; }

        /// <summary>
        /// An MD5 checksum for the content of this file.
        /// </summary>
        /// <remarks>
        /// This field is only populated for files with content stored in Drive;
        /// it is not populated for Google Docs or shortcut files.
        /// </remarks>
        public string Md5Checksum { get; set; }

        /// <summary>
        /// The size of the file in bytes.
        /// </summary>
        /// <remarks>
        /// This field is only populated for files with content stored in Drive;
        /// it is not populated for Google Docs or shortcut files.
        /// </remarks>
        public long? FileSize { get; set; }

        /// <summary>
        /// The number of quota bytes used by this file.
        /// </summary>
        public long? QuotaBytesUsed { get; set; }

        /// <summary>
        /// Name(s) of the owner(s) of this file.
        /// </summary>
        public IList<string> OwnerNames { get; set; }

        /// <summary>
        /// The owner(s) of this file.
        /// </summary>
        public IList<User> Owners { get; set; }

        /// <summary>
        /// Name of the last user to modify this file.
        /// </summary>
        public string LastModifyingUserName { get; set; }

        /// <summary>
        /// The last user to modify this file.
        /// </summary>
        public User LastModifyingUser { get; set; }

        /// <summary>
        /// Whether the file is owned by the current user.
        /// </summary>
        public bool? OwnedByMe { get; set; }

        /// <summary>
        /// Whether the file can be edited by the current user.
        /// </summary>
        public bool? Editable { get; set; }

        /// <summary>
        /// Whether the current user can comment on the file.
        /// </summary>
        public bool? CanComment { get; set; }

        /// <summary>
        /// Whether the file's sharing settings can be modified by the current user.
        /// </summary>
        public bool? Shareable { get; set; }

        /// <summary>
        /// Whether the file can be copied by the current user.
        /// </summary>
        public bool? Copyable { get; set; }

        /// <summary>
        /// Whether writers can share the document with other users.
        /// </summary>
        public bool? WritersCanShare { get; set; }

        /// <summary>
        /// Whether the file has been shared.
        /// </summary>
        public bool? Shared { get; set; }

        /// <summary>
        /// Whether this file has been explicitly trashed, as opposed to recursively trashed.
        /// </summary>
        public bool? ExplicitlyTrashed { get; set; }

        /// <summary>
        /// Whether this file is in the Application Data folder.
        /// </summary>
        public bool? AppDataContents { get; set; }

        /// <summary>
        /// The ID of the file's head revision.
        /// </summary>
        /// <remarks>
        /// This field is only populated for files with content stored in Drive;
        /// it is not populated for Google Docs or shortcut files.
        /// </remarks>
        public string HeadRevisionId { get; set; }

        /// <summary>
        /// The list of properties.
        /// </summary>
        public IList<Property> Properties { get; set; }

        /// <summary>
        /// Folder color as an RGB hex string if the file is a folder.
        /// </summary>
        /// <remarks>
        /// The list of supported colors is available in the <see cref="About.FolderColorPalette"/>
        /// field of the About resource. If an unsupported color is specified,
        /// it will be changed to the closest color in the palette.
        /// </remarks>
        public string FolderColorRgb { get; set; }

        /// <summary>
        /// Metadata about image media.
        /// </summary>
        /// <remarks>
        /// This will only be present for image types,
        /// and its contents will depend on what can be
        /// parsed from the image content.
        /// </remarks>
        public ImageMediaMetadata ImageMediaMetadata { get; set; }

        /// <summary>
        /// Metadata about video media.
        /// </summary>
        /// <remarks>
        /// This will only be present for video types. 	
        /// </remarks>
        public VideoMediaMetadata VideoMediaMetadata { get; set; }

        /// <summary>
        /// The list of spaces which contain the file.
        /// </summary>
        /// <remarks>
        /// Supported values are 'drive', 'appDataFolder' and 'photos'.
        /// </remarks>
        public IList<string> Spaces { get; set; }

        /// <summary>
        /// Gibt eine Zeichenfolge zurück, die das aktuelle Objekt darstellt.
        /// </summary>
        /// <returns>
        /// Eine Zeichenfolge, die das aktuelle Objekt darstellt.
        /// </returns>
        public override string ToString()
        {
            return Title;
        }
    }
}
