using System.Collections.Generic;

namespace RestSharp.Portable.Google.Drive.Model
{
    /// <summary>
    /// Import or export format
    /// </summary>
    public class Format
    {
        /// <summary>
        /// The content type to convert from.
        /// </summary>
        public string Source { get; set; }

        /// <summary>
        /// The possible content types to convert to.
        /// </summary>
        public IList<string> Targets { get; set; }
    }
}
