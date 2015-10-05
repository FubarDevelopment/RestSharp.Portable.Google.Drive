namespace RestSharp.Portable.Google.Drive.Model
{
    /// <summary>
    /// Metadata about video media.
    /// </summary>
    public class VideoMediaMetadata
    {
        /// <summary>
        /// The width of the video in pixels.
        /// </summary>
        public int? Width { get; set; }

        /// <summary>
        /// The height of the video in pixels.
        /// </summary>
        public int? Height { get; set; }

        /// <summary>
        /// The duration of the video in milliseconds.
        /// </summary>
        public long? DurationMillis { get; set; }
    }
}
