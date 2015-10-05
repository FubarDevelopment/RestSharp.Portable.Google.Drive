using System.Collections.Generic;

namespace RestSharp.Portable.Google.Drive.Model
{
    /// <summary>
    /// The supported additional roles per primary role.
    /// </summary>
    public class RoleSet
    {
        /// <summary>
        /// A primary permission role.
        /// </summary>
        public string PrimaryRole { get; set; }

        /// <summary>
        /// The supported additional roles with the primary role.
        /// </summary>
        public IList<string> AdditionalRoles { get; set; }
    }
}
