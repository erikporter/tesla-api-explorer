using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace TeslaApiExplorer.Models
{
    public class TeslaApiListResponse<T>
    {
        [JsonPropertyName("response")]
        public IEnumerable<T> Response { get; set; }

        [JsonPropertyName("count")]
        public int Count { get; set; }
    }
}
