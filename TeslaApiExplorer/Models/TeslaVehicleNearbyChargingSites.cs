using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace TeslaApiExplorer.Models
{
    public class TeslaVehicleNearbyChargingSites
    {
        [JsonPropertyName("congestion_sync_time_utc_secs")]
        public int CongestionSyncTimeUtcSecs { get; set; }

        [JsonPropertyName("destination_charging")]
        public IEnumerable<TeslaVehicleDestinationCharging> DestinationCharging { get; set; }

        [JsonPropertyName("superchargers")]
        public IEnumerable<TeslaVehicleSuperCharger> SuperChargers { get; set; }

        [JsonPropertyName("timestamp")]
        public long Timestamp { get; set; }
    }
}
