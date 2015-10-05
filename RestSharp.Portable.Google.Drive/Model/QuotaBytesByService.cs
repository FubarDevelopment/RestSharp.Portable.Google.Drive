namespace RestSharp.Portable.Google.Drive.Model
{
    /// <summary>
    /// The amount of storage quota used by a Google service.
    /// </summary>
    public class QuotaBytesByService
    {
        /// <summary>
        /// The service's name, e.g. DRIVE, GMAIL, or PHOTOS.
        /// </summary>
        public string ServiceName { get; set; }

        /// <summary>
        /// The storage quota bytes used by the service.
        /// </summary>
        public long BytesUsed { get; set; }
    }
}
