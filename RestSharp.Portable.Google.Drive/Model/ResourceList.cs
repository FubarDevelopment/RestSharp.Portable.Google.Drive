using System.Collections.Generic;

namespace RestSharp.Portable.Google.Drive.Model
{
    /// <summary>
    /// Base type for resource lists
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ResourceList<T>
    {
        /// <summary>
        /// The kind of resource
        /// </summary>
        public string Kind { get; set; }

        /// <summary>
        /// The ETag of the item.
        /// </summary>
        public string Etag { get; set; }

        /// <summary>
        /// A link back to this item.
        /// </summary>
        public string SelfLink { get; set; }

        /// <summary>
        /// All items
        /// </summary>
        public List<T> Items { get; set; }
    }
}
