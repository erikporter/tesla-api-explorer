using System.Text.Json.Serialization;

namespace TeslaApiExplorer.Models
{
    public class TeslaVehicleDestinationCharging
    {
        [JsonPropertyName("location")]
        public TeslaLocation Location { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("distance_miles")]
        public float DistanceMiles { get; set; }
    }
}
