using System.Text.Json.Serialization;

namespace TeslaApiExplorer.Models
{
    public class TeslaLocation
    {
        [JsonPropertyName("lat")]
        public float Latitude { get; set; }

        [JsonPropertyName("long")]
        public float Longitude { get; set; }
    }
}
