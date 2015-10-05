using System.Runtime.Serialization;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace RestSharp.Portable.Google.Drive.Model
{
    /// <summary>
    /// The type of the user's storage quota.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum QuotaType
    {
        /// <summary>
        /// Limited quota
        /// </summary>
        [EnumMember(Value = "LIMITED")]
        Limited,

        /// <summary>
        /// Unlimited quota
        /// </summary>
        [EnumMember(Value = "UNLIMITED")]
        Unlimited,
    }
}
