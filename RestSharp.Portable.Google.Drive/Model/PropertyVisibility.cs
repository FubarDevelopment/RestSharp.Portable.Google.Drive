using System.Runtime.Serialization;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace RestSharp.Portable.Google.Drive.Model
{
    /// <summary>
    /// The visibility of a property.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum PropertyVisibility
    {
        /// <summary>
        /// The property is visible by all apps.
        /// </summary>
        [EnumMember(Value = "PUBLIC")]
        Public,

        /// <summary>
        /// The property is only available to the app that created it.
        /// </summary>
        [EnumMember(Value = "PRIVATE")]
        Private
    }
}
