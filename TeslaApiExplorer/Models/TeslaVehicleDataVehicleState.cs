using System.Text.Json.Serialization;

namespace TeslaApiExplorer.Models
{
    public class TeslaVehicleDataVehicleState
    {
        [JsonPropertyName("api_version")]
        public int ApiVersion { get; set; }

        [JsonPropertyName("autopark_state_v2")]
        public string AutoparkStateV2 { get; set; }

        [JsonPropertyName("autopark_style")]
        public string AutoparkStyle { get; set; }

        [JsonPropertyName("calendar_supported")]
        public bool CalendarSupported { get; set; }

        [JsonPropertyName("car_version")]
        public string CarVersion { get; set; }

        [JsonPropertyName("center_display_state")]
        public int CenterDisplayState { get; set; }

        [JsonPropertyName("df")]
        public int DriverFront { get; set; }

        [JsonPropertyName("dr")]
        public int DriverRear { get; set; }

        [JsonPropertyName("fd_window")]
        public int FrontDriverWindow { get; set; }

        [JsonPropertyName("fp_window")]
        public int FrontPassengerWindow { get; set; }

        [JsonPropertyName("ft")]
        public int FrontTrunk { get; set; }

        [JsonPropertyName("homelink_device_count")]
        public int HomelinkDeviceCount { get; set; }

        [JsonPropertyName("homelink_nearby")]
        public bool HomelinkNearby { get; set; }

        [JsonPropertyName("is_user_present")]
        public bool IsUserPresent { get; set; }

        [JsonPropertyName("last_autopark_error")]
        public string LastAutoparkError { get; set; }

        [JsonPropertyName("locked")]
        public bool Locked { get; set; }

        [JsonPropertyName("media_state")]
        public TeslaVehicleDataMediaState MediaState { get; set; }

        [JsonPropertyName("notifications_supported")]
        public bool NotificationsSupported { get; set; }

        [JsonPropertyName("odometer")]
        public float Odometer { get; set; }

        [JsonPropertyName("parsed_calendar_supported")]
        public bool ParsedCalendarSupported { get; set; }

        [JsonPropertyName("pf")]
        public int PassengerFront { get; set; }

        [JsonPropertyName("pr")]
        public int PassengerRear { get; set; }

        [JsonPropertyName("rd_window")]
        public int RearDriverWindow { get; set; }

        [JsonPropertyName("remote_start")]
        public bool RemoteStart { get; set; }

        [JsonPropertyName("remote_start_enabled")]
        public bool RemoteStartEnabled { get; set; }

        [JsonPropertyName("remote_start_supported")]
        public bool RemoteStartSupported { get; set; }

        [JsonPropertyName("rp_window")]
        public int RearPassengerWindow { get; set; }

        [JsonPropertyName("rt")]
        public int RearTrunk { get; set; }

        [JsonPropertyName("sentry_mode")]
        public bool SentryMode { get; set; }

        [JsonPropertyName("sentry_mode_available")]
        public bool SentryModeAvailable { get; set; }

        [JsonPropertyName("smart_summon_available")]
        public bool SmartSummonAvailable { get; set; }

        [JsonPropertyName("software_update")]
        public TeslaVehicleDataSoftwareUpdate SoftwareUpdate { get; set; }

        [JsonPropertyName("speed_limit_mode")]
        public TeslaVehicleDataSpeedLimitMode SpeedLimitMode { get; set; }

        [JsonPropertyName("summon_standby_mode_enabled")]
        public bool SummonStandbyModeEnabled { get; set; }

        [JsonPropertyName("sun_roof_percent_open")]
        public int SunRoofPercentPpen { get; set; }

        [JsonPropertyName("sun_roof_state")]
        public string SunRoofState { get; set; }

        [JsonPropertyName("timestamp")]
        public long Timestamp { get; set; }

        [JsonPropertyName("valet_mode")]
        public bool ValetMode { get; set; }

        [JsonPropertyName("valet_pin_needed")]
        public bool ValetPinNeeded { get; set; }

        [JsonPropertyName("vehicle_name")]
        public string VehicleName { get; set; }
    }
}
