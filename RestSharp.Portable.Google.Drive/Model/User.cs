namespace RestSharp.Portable.Google.Drive.Model
{
    /// <summary>
    /// A Google user
    /// </summary>
    public class User
    {
        /// <summary>
        /// This is always <code>drive#user</code>.
        /// </summary>
        public string Kind { get; set; }

        /// <summary>
        /// A plain text displayable name for this user.
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// The user's profile picture.
        /// </summary>
        public Picture Picture { get; set; }

        /// <summary>
        /// Whether this user is the same as the authenticated user for whom the request was made.
        /// </summary>
        public bool IsAuthenticatedUser { get; set; }

        /// <summary>
        /// The user's ID as visible in the permissions collection.
        /// </summary>
        public string PermissionId { get; set; }

        /// <summary>
        /// The email address of the user.
        /// </summary>
        public string EmailAddress { get; set; }

        /// <summary>
        /// Returns the <see cref="DisplayName"/>
        /// </summary>
        /// <returns>the <see cref="DisplayName"/></returns>
        public override string ToString()
        {
            return DisplayName;
        }
    }
}