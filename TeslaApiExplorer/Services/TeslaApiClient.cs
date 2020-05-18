using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using TeslaApiExplorer.Extensions;
using TeslaApiExplorer.Models;

namespace TeslaApiExplorer.Services
{
    public class TeslaApiClient
    {
        private readonly HttpClient client;
        private readonly TeslaAppSettings appSettings;

        public TeslaApiClient(HttpClient client, TeslaAppSettings appSettings)
        {
            this.client = client;
            this.appSettings = appSettings;
        }

        public Task<TeslaApiResult<TeslaAuthorization>> GetAuthorizationAsync(string email, string password) =>
            GetAuthorizationAsync("/oauth/token", new TeslaOauthRequest
            {
                GrantType = "password",
                ClientId = appSettings.TeslaApiClientId,
                ClientSecret = appSettings.TeslaApiClientSecret,
                Email = email,
                Password = password
            });

        public Task<TeslaApiResult<TeslaAuthorization>> GetAuthorizationAsync(string refreshToken) =>
            GetAuthorizationAsync("/oauth/token", new TeslaOauthRequest
            {
                GrantType = "refresh_token",
                ClientId = appSettings.TeslaApiClientId,
                ClientSecret = appSettings.TeslaApiClientSecret,
                RefreshToken = refreshToken
            });

        public Task<TeslaApiResult<TeslaApiListResponse<TeslaVehicle>>> GetVehiclesAsync(TeslaAuthorization authorization) =>
            GetAsync<TeslaApiListResponse<TeslaVehicle>>("/api/1/vehicles", authorization);

        public Task<TeslaApiResult<TeslaApiResponse<TeslaVehicle>>> GetVehicleAsync(TeslaAuthorization authorization, long vehicleId) =>
            GetAsync<TeslaApiResponse<TeslaVehicle>>($"/api/1/vehicles/{vehicleId}", authorization);

        public Task<TeslaApiResult<TeslaApiResponse<TeslaVehicleData>>> GetVehicleDataAsync(TeslaAuthorization authorization, long vehicleId) =>
            GetAsync<TeslaApiResponse<TeslaVehicleData>>($"/api/1/vehicles/{vehicleId}/vehicle_data", authorization);

        public Task<TeslaApiResult<TeslaApiResponse<TeslaVehicleDataChargeState>>> GetVehicleDataChargeStateAsync(TeslaAuthorization authorization, long vehicleId) =>
            GetAsync<TeslaApiResponse<TeslaVehicleDataChargeState>>($"/api/1/vehicles/{vehicleId}/data_request/charge_state", authorization);

        public Task<TeslaApiResult<TeslaApiResponse<TeslaVehicleDataClimateState>>> GetVehicleDataClimateStateAsync(TeslaAuthorization authorization, long vehicleId) =>
            GetAsync<TeslaApiResponse<TeslaVehicleDataClimateState>>($"/api/1/vehicles/{vehicleId}/data_request/climate_state", authorization);

        public Task<TeslaApiResult<TeslaApiResponse<TeslaVehicleDataDriveState>>> GetVehicleDataDriveStateAsync(TeslaAuthorization authorization, long vehicleId) =>
            GetAsync<TeslaApiResponse<TeslaVehicleDataDriveState>>($"/api/1/vehicles/{vehicleId}/data_request/drive_state", authorization);

        public Task<TeslaApiResult<TeslaApiResponse<TeslaVehicleDataGuiSettings>>> GetVehicleDataGuiSettingsAsync(TeslaAuthorization authorization, long vehicleId) =>
            GetAsync<TeslaApiResponse<TeslaVehicleDataGuiSettings>>($"/api/1/vehicles/{vehicleId}/data_request/gui_settings", authorization);

        public Task<TeslaApiResult<TeslaApiResponse<TeslaVehicleDataVehicleState>>> GetVehicleDataVehicleStateAsync(TeslaAuthorization authorization, long vehicleId) =>
            GetAsync<TeslaApiResponse<TeslaVehicleDataVehicleState>>($"/api/1/vehicles/{vehicleId}/data_request/vehicle_state", authorization);

        public Task<TeslaApiResult<TeslaApiResponse<TeslaVehicleDataVehicleConfig>>> GetVehicleDataVehicleConfigAsync(TeslaAuthorization authorization, long vehicleId) =>
            GetAsync<TeslaApiResponse<TeslaVehicleDataVehicleConfig>>($"/api/1/vehicles/{vehicleId}/data_request/vehicle_config", authorization);

        public Task<TeslaApiResult<TeslaApiResponse<bool>>> GetVehicleMobileEnabledAsync(TeslaAuthorization authorization, long vehicleId) =>
            GetAsync<TeslaApiResponse<bool>>($"/api/1/vehicles/{vehicleId}/mobile_enabled", authorization);

        public Task<TeslaApiResult<TeslaApiResponse<TeslaVehicleNearbyChargingSites>>> GetVehicleNearbyChargingSitesAsync(TeslaAuthorization authorization, long vehicleId) =>
            GetAsync<TeslaApiResponse<TeslaVehicleNearbyChargingSites>>($"/api/1/vehicles/{vehicleId}/nearby_charging_sites", authorization);

        private async Task<TeslaApiResult<TeslaAuthorization>> GetAuthorizationAsync(string url, TeslaOauthRequest request)
        {
            var response = await client.SendAsync(HttpMethod.Post, url, content: request);

            if (!response.IsSuccessStatusCode)
                return new TeslaApiResult<TeslaAuthorization> { Error = await response.Content.ReadAsStringAsync() };

            var responseContent = await JsonSerializer.DeserializeAsync<TeslaAuthorization>(await response.Content.ReadAsStreamAsync());

            return new TeslaApiResult<TeslaAuthorization> { Content = responseContent };
        }

        private async Task<TeslaApiResult<T>> GetAsync<T>(string url, TeslaAuthorization authorization)
        {
            if (authorization == null)
                return new TeslaApiResult<T>();

            var response = await client.SendAsync(HttpMethod.Get, url, authorization: authorization);

            if (!response.IsSuccessStatusCode)
                return new TeslaApiResult<T> { Error = await response.Content.ReadAsStringAsync() };

            return new TeslaApiResult<T> { Content = await JsonSerializer.DeserializeAsync<T>(await response.Content.ReadAsStreamAsync()) };
        }
    }
}
