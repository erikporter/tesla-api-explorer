using System.Text.Json.Serialization;

namespace TeslaApiExplorer.Models
{
    public class TeslaVehicleSuperCharger
    {
        [JsonPropertyName("location")]
        public TeslaLocation Location { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("distance_miles")]
        public float DistanceMiles { get; set; }

        [JsonPropertyName("available_stalls")]
        public int AvailableStalls { get; set; }

        [JsonPropertyName("total_stalls")]
        public int TotalStalls { get; set; }

        [JsonPropertyName("site_closed")]
        public bool SiteClosed { get; set; }
    }
}
