namespace RestSharp.Portable.Google.Drive.Model
{
    /// <summary>
    /// A reference to a folder's child
    /// </summary>
    public class ChildReference
    {
        /// <summary>
        /// This is always <code>drive#childReference</code>.
        /// </summary>
        public string Kind { get; set; }

        /// <summary>
        /// The ID of the child.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// A link back to this reference.
        /// </summary>
        public string SelfLink { get; set; }

        /// <summary>
        /// A link to the child.
        /// </summary>
        public string ChildLink { get; set; }
    }
}
