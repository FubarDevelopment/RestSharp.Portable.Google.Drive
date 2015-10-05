namespace RestSharp.Portable.Google.Drive.Model
{
    /// <summary>
    /// A permission for a file.
    /// </summary>
    public class Permission
    {
        /// <summary>
        /// This is always <code>drive#permission</code>.
        /// </summary>
        public string Kind { get; set; }

        /// <summary>
        /// The ETag of the permission.
        /// </summary>
        public string Etag { get; set; }

        /// <summary>
        /// The ID of the user this permission refers to, and identical to
        /// the <see cref="About.PermissionId"/> and <see cref="File.Permissions"/>.
        /// </summary>
        /// <remarks>
        /// When making a drive.permissions.insert request, exactly one of the <see cref="Id"/>
        /// or <see cref="Value"/> fields must be specified.
        /// </remarks>
        public string Id { get; set; }

        /// <summary>
        /// A link back to this permission.
        /// </summary>
        public string SelfLink { get; set; }

        /// <summary>
        /// The name for this permission.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The primary role for this user.
        /// </summary>
        public Role? Role { get; set; }

        /// <summary>
        /// The account type.
        /// </summary>
        public AccountType? Type { get; set; }

        /// <summary>
        /// The authkey parameter required for this permission.
        /// </summary>
        public string AuthKey { get; set; }

        /// <summary>
        /// Whether the link is required for this permission.
        /// </summary>
        public bool? WithLink { get; set; }

        /// <summary>
        /// A link to the profile photo, if available.
        /// </summary>
        public string PhotoLink { get; set; }

        /// <summary>
        /// The email address or domain name for the entity.
        /// </summary>
        /// <remarks>
        /// <para>This is used during inserts and is not populated in responses.</para>
        /// <para>When making a <code>drive.permissions.insert</code> request, exactly one
        /// of the <see cref="Id"/> or <see cref="Value"/> fields must be specified.</para>
        /// </remarks>
        public string Value { get; set; }

        /// <summary>
        /// The email address of the user or group this permission refers to.
        /// </summary>
        /// <remarks>
        /// This is an output-only field which is present when the permission type is user or group.
        /// </remarks>
        public string EmailAddress { get; set; }

        /// <summary>
        /// The domain name of the entity this permission refers to.
        /// </summary>
        /// <remarks>
        /// This is an output-only field which is present when the permission type is user, group or domain.
        /// </remarks>
        public string Domain { get; set; }
    }
}
