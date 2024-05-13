using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transmission.API.RPC.Entity;

namespace Transmission.API.RPC.Common
{
    /// <summary>
    /// Transmission response 
    /// </summary>
    public class TransmissionResponse : CommunicateBase
    {
        /// <summary>
        /// Contains "success" on success, or an error string on failure.
        /// </summary>
        [JsonPropertyName("result")]
        public string Result;
    }

    [JsonSourceGenerationOptions(IncludeFields = true)]
    [JsonSerializable(typeof(TransmissionResponse))]
    internal partial class TransmissionResponseContext : JsonSerializerContext
    {
    }
}
