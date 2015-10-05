using System.Runtime.Serialization;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace RestSharp.Portable.Google.Drive.Model
{
    /// <summary>
    /// The domain sharing policy for the user
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum DomainSharingPolicy
    {
        /// <summary>
        /// Domain sharing allowed
        /// </summary>
        [EnumMember(Value = "allowed")]
        Allowed,

        /// <summary>
        /// Domain sharing allowed with warning
        /// </summary>
        [EnumMember(Value = "allowedWithWarning")]
        AllowedWithWarning,

        /// <summary>
        /// Only incoming
        /// </summary>
        [EnumMember(Value = "incomingOnly")]
        IncomingOnly,

        /// <summary>
        /// Domain sharing disallowed
        /// </summary>
        [EnumMember(Value = "disallowed")]
        Disallowed,
    }
}
