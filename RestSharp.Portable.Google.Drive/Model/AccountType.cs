using System.Runtime.Serialization;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace RestSharp.Portable.Google.Drive.Model
{
    /// <summary>
    /// The account type
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum AccountType
    {
        /// <summary>
        /// User account
        /// </summary>
        [EnumMember(Value = "user")]
        User,

        /// <summary>
        /// Group
        /// </summary>
        [EnumMember(Value = "group")]
        Group,

        /// <summary>
        /// Domain
        /// </summary>
        [EnumMember(Value = "domain")]
        Domain,

        /// <summary>
        /// Anyone
        /// </summary>
        [EnumMember(Value = "anyone")]
        Anyone,
    }
}
