namespace RestSharp.Portable.Google.Drive.Model
{
    /// <summary>
    /// List of max upload sizes for a file type.
    /// </summary>
    public class MaxUploadSize
    {
        /// <summary>
        /// The file type.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// The max upload size for this type.
        /// </summary>
        public long Size { get; set; }
    }
}
