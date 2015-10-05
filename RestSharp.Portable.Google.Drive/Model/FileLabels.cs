using System;

namespace RestSharp.Portable.Google.Drive.Model
{
    /// <summary>
    /// A group of labels for a file.
    /// </summary>
    public class FileLabels
    {
        /// <summary>
        /// Whether this file is starred by the user.
        /// </summary>
        public bool Starred { get; set; }

        /// <summary>
        /// Deprecated
        /// </summary>
        [Obsolete]
        public bool Hidden { get; set; }

        /// <summary>
        /// Whether this file has been trashed.
        /// </summary>
        /// <remarks>
        /// This label applies to all users accessing the file;
        /// however, only owners are allowed to see and untrash files.
        /// </remarks>
        public bool Trashed { get; set; }

        /// <summary>
        /// Whether viewers and commenters are prevented from downloading, printing, and copying this file.
        /// </summary>
        public bool Restricted { get; set; }

        /// <summary>
        /// Whether this file has been viewed by this user.
        /// </summary>
        public bool Viewed { get; set; }
    }
}
