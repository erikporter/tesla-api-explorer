using System.Text.Json.Serialization;

namespace TeslaApiExplorer.Models
{
    public class TeslaVehicleDataMediaState
    {
        [JsonPropertyName("remote_control_enabled")]
        public bool RemoteControlEnabled { get; set; }
    }
}
