namespace RestSharp.Portable.Google.Drive.Model
{
    /// <summary>
    /// Thumbnail for a file.
    /// </summary>
    public class Thumbnail
    {
        /// <summary>
        /// The URL-safe Base64 encoded bytes of the thumbnail image.
        /// </summary>
        /// <remarks>
        /// It should conform to RFC 4648 section 5.
        /// </remarks>
        public byte[] Image { get; set; }

        /// <summary>
        /// The MIME type of the thumbnail.
        /// </summary>
        public string MimeType { get; set; }
    }
}
