using System.Collections.Generic;

namespace RestSharp.Portable.Google.Drive.Model
{
    /// <summary>
    /// Information about supported additional roles per file type. The most specific type takes precedence.
    /// </summary>
    public class AdditionalRoleInfo
    {
        /// <summary>
        /// The content type that this additional role info applies to.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// The supported additional roles per primary role.
        /// </summary>
        public IList<RoleSet> RoleSets { get; set; }
    }
}
