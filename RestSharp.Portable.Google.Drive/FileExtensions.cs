using RestSharp.Portable.Google.Drive.Model;

namespace RestSharp.Portable.Google.Drive
{
    /// <summary>
    /// Extension methods for the <see cref="File"/> type
    /// </summary>
    public static class FileExtensions
    {
        /// <summary>
        /// Mime type for a directory entry
        /// </summary>
        public static string DirectoryMimeType => "application/vnd.google-apps.folder";

        /// <summary>
        /// Test if <paramref name="file"/> is a sub directory
        /// </summary>
        /// <param name="file">The <see cref="File"/> to test for being a sub directory</param>
        /// <returns><code>true</code> when <paramref name="file"/> is a sub directory</returns>
        public static bool IsDirectory(this File file)
        {
            return file.MimeType == DirectoryMimeType;
        }
    }
}
