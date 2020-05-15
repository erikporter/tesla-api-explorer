using System.Text.Json.Serialization;

namespace TeslaApiExplorer.Models
{
    public class TeslaVehicleData : TeslaVehicle
    {
        [JsonPropertyName("drive_state")]
        public TeslaVehicleDataDriveState DriveState { get; set; }

        [JsonPropertyName("climate_state")]
        public TeslaVehicleDataClimateState ClimateState { get; set; }

        [JsonPropertyName("charge_state")]
        public TeslaVehicleDataChargeState ChargeState { get; set; }

        [JsonPropertyName("gui_settings")]
        public TeslaVehicleDataGuiSettings GuiSettings { get; set; }

        [JsonPropertyName("vehicle_state")]
        public TeslaVehicleDataVehicleState VehicleState { get; set; }

        [JsonPropertyName("vehicle_config")]
        public TeslaVehicleDataVehicleConfig VehicleConfig { get; set; }
    }
}
