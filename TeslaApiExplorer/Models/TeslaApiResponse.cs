using System.Text.Json.Serialization;

namespace TeslaApiExplorer.Models
{
    public class TeslaApiResponse<T>
    {
        [JsonPropertyName("response")]
        public T Response { get; set; }
    }
}
