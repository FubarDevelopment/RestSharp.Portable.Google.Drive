namespace RestSharp.Portable.Google.Drive.Model
{
    /// <summary>
    /// List of additional features enabled for an account.
    /// </summary>
    public class Feature
    {
        /// <summary>
        /// The name of the feature.
        /// </summary>
        public string FeatureName { get; set; }

        /// <summary>
        /// The request limit rate for this feature, in queries per second.
        /// </summary>
        public decimal FeatureRate { get; set; }
    }
}
