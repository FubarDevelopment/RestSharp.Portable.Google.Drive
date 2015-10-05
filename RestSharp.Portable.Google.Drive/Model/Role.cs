using System.Runtime.Serialization;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace RestSharp.Portable.Google.Drive.Model
{
    /// <summary>
    /// The role for a permission
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum Role
    {
        /// <summary>
        /// Owner
        /// </summary>
        [EnumMember(Value = "owner")]
        Owner,

        /// <summary>
        /// Reader
        /// </summary>
        [EnumMember(Value = "reader")]
        Reader,

        /// <summary>
        /// Writer
        /// </summary>
        [EnumMember(Value = "writer")]
        Writer
    }
}
