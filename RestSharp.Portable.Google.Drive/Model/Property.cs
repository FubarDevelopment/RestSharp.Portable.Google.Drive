namespace RestSharp.Portable.Google.Drive.Model
{
    /// <summary>
    /// A file property
    /// </summary>
    public class Property
    {
        /// <summary>
        /// This is always <code>drive#property</code>.
        /// </summary>
        public string Kind { get; set; }

        /// <summary>
        /// ETag of the property.
        /// </summary>
        public string Etag { get; set; }

        /// <summary>
        /// The link back to this property.
        /// </summary>
        public string SelfLink { get; set; }

        /// <summary>
        /// The key of this property.
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// The visibility of this property.
        /// </summary>
        public PropertyVisibility Visibility { get; set; }

        /// <summary>
        /// The value of this property.
        /// </summary>
        public string Value { get; set; }
    }
}
