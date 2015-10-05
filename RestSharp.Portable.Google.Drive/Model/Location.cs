namespace RestSharp.Portable.Google.Drive.Model
{
    /// <summary>
    /// Geographic location information.
    /// </summary>
    public class Location
    {
        /// <summary>
        /// The latitude
        /// </summary>
        public decimal? Latitude { get; set; }

        /// <summary>
        /// The longitude
        /// </summary>
        public decimal? Longitude { get; set; }

        /// <summary>
        /// The altitude
        /// </summary>
        public decimal? Altitude { get; set; }
    }
}
