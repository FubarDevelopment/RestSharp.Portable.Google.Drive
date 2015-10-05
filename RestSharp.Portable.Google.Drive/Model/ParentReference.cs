namespace RestSharp.Portable.Google.Drive.Model
{
    /// <summary>
    /// A reference to a file's parent.
    /// </summary>
    public class ParentReference
    {
        /// <summary>
        /// This is always <code>drive#parentReference</code>.
        /// </summary>
        public string Kind { get; set; }

        /// <summary>
        /// The ID of the parent.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// A link back to this reference.
        /// </summary>
        public string SelfLink { get; set; }

        /// <summary>
        /// A link to the parent.
        /// </summary>
        public string ParentLink { get; set; }

        /// <summary>
        /// Whether or not the parent is the root folder.
        /// </summary>
        public bool? IsRoot { get; set; }
    }
}
