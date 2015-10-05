using System.Collections.Generic;

namespace RestSharp.Portable.Google.Drive.Model
{
    /// <summary>
    /// Information about the current user along with Drive API settings
    /// </summary>
    public class About
    {
        /// <summary>
        /// This is always <code>drive#about</code>.
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
        /// The name of the current user.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The authenticated user.
        /// </summary>
        public User User { get; set; }

        /// <summary>
        /// The total number of quota bytes.
        /// </summary>
        public long QuotaBytesTotal { get; set; }

        /// <summary>
        /// The number of quota bytes used by Google Drive.
        /// </summary>
        public long QuoteBytesUsed { get; set; }

        /// <summary>
        /// The number of quota bytes used by all Google apps (Drive, Picasa, etc.).
        /// </summary>
        public long QuoteBytesUsedAggregate { get; set; }

        /// <summary>
        /// The number of quota bytes used by trashed items. 	
        /// </summary>
        public long QuoteBytesUsedInTrash { get; set; }

        /// <summary>
        /// The type of the user's storage quota.
        /// </summary>
        public QuotaType? QuotaType { get; set; }

        /// <summary>
        /// The amount of storage quota used by different Google services
        /// </summary>
        public IList<QuotaBytesByService> QuotaBytesByService { get; set; }

        /// <summary>
        /// The largest change id.
        /// </summary>
        public long LargestChangeId { get; set; }

        /// <summary>
        /// The number of remaining change ids.
        /// </summary>
        public long RemainingChangeIds { get; set; }

        /// <summary>
        /// The id of the root folder.
        /// </summary>
        public string RootFolderId { get; set; }

        /// <summary>
        /// The domain sharing policy for the current user.
        /// </summary>
        public string DomainSharingPolicy { get; set; }

        /// <summary>
        /// The current user's ID as visible in the permissions collection.
        /// </summary>
        public string PermissionId { get; set; }

        /// <summary>
        /// The allowable import formats.
        /// </summary>
        public IList<Format> ImportFormats { get; set; }

        /// <summary>
        /// The allowable export formats.
        /// </summary>
        public IList<Format> ExportFormats { get; set; }

        /// <summary>
        /// Information about supported additional roles per file type.
        /// </summary>
        /// <remarks>
        /// The most specific type takes precedence.
        /// </remarks>
        public IList<AdditionalRoleInfo> AdditionalRoleInfo { get; set; }

        /// <summary>
        /// List of additional features enabled on this account.
        /// </summary>
        public IList<Feature> Features { get; set; }

        /// <summary>
        /// List of max upload sizes for each file type.
        /// </summary>
        /// <remarks>
        /// The most specific type takes precedence.
        /// </remarks>
        public IList<MaxUploadSize> MaxUploadSizes { get; set; }

        /// <summary>
        /// A value indicating whether the authenticated app is installed by the authenticated user.
        /// </summary>
        public bool IsCurrentAppInstalled { get; set; }

        /// <summary>
        /// The user's language or locale code, as defined by BCP 47, with some extensions from Unicode's LDML format.
        /// </summary>
        /// <remarks>
        /// http://www.unicode.org/reports/tr35/
        /// </remarks>
        public string LanguageCode { get; set; }

        /// <summary>
        /// The palette of allowable folder colors as RGB hex strings.
        /// </summary>
        public IList<string> FolderColorPalette { get; set; }
    }
}
