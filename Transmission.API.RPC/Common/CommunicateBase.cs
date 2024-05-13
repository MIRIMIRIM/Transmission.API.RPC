using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using Transmission.API.RPC.Entity;
using System.Text.Json.Serialization.Metadata;

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
            return JsonSerializer.Serialize(this, CommunicateBaseContext.Default.CommunicateBase);
        }

        /// <summary>
        /// Deserialize to class
        /// </summary>
        /// <returns></returns>
        public T Deserialize<T>(JsonTypeInfo<T> jsonTypeInfo)
        {
            var argumentsString = JsonSerializer.Serialize(this.Arguments, ArgumentsContext.Default.DictionaryStringObject);
            return JsonSerializer.Deserialize(argumentsString, jsonTypeInfo);
        }
    }

    [JsonSourceGenerationOptions(IncludeFields = true)]
    [JsonSerializable(typeof(CommunicateBase))]
    [JsonSerializable(typeof(TransmissionRequest))]
    [JsonSerializable(typeof(TransmissionResponse))]
    internal partial class CommunicateBaseContext : JsonSerializerContext
    {
    }

    [JsonSourceGenerationOptions(IncludeFields = true)]
    [JsonSerializable(typeof(Dictionary<string, object>))]
    [JsonSerializable(typeof(JsonElement))]
    internal partial class ArgumentsContext : JsonSerializerContext
    {
    }
}
