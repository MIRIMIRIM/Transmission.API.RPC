using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Transmission.API.RPC.Common
{
    /// <summary>
    /// Base class for request/response
    /// </summary>
    [JsonDerivedType(typeof(CommunicateBase), typeDiscriminator: "base")]
    [JsonDerivedType(typeof(TransmissionRequest), typeDiscriminator: "request")]
    [JsonDerivedType(typeof(TransmissionResponse), typeDiscriminator: "response")]
    public class CommunicateBase
    {
        /// <summary>
        /// Data
        /// </summary>
        [JsonPropertyName("arguments")]
        public Dictionary<string, object> Arguments;

        /// <summary>
        /// Number (id)
        /// </summary>
        [JsonPropertyName("tag")]
        public int Tag;

        /// <summary>
        /// Convert to JSON string
        /// </summary>
        /// <returns></returns>
        public virtual string ToJson()
        {
            var options = new JsonSerializerOptions { WriteIndented = true, IncludeFields = true };
            return JsonSerializer.Serialize(this, options);
        }

        /// <summary>
        /// Deserialize to class
        /// </summary>
        /// <returns></returns>
        public T Deserialize<T>()
        {
            var options = new JsonSerializerOptions { IncludeFields = true };
            var argumentsString = JsonSerializer.Serialize(this.Arguments);
            return JsonSerializer.Deserialize<T>(argumentsString, options);
        }
    }
}
