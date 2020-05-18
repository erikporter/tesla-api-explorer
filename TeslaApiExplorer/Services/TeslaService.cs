using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeslaApiExplorer.Models;

namespace TeslaApiExplorer.Services
{
    public class TeslaService
    {
        private readonly TeslaApiClient apiClient;
        private readonly IStorageService storageService;
        private const string authorizationFileName = "authorization.json";

        public TeslaService(TeslaApiClient apiClient, IStorageService storageService)
        {
            this.apiClient = apiClient;
            this.storageService = storageService;
        }

        public async Task<TeslaAuthorization> GetAuthorizationAsync(string email, string password)
        {
            var result = await apiClient.GetAuthorizationAsync(email, password);

            if (!string.IsNullOrEmpty(result.Error))
                return null;

            return result.Content;
        }

        public TeslaAuthorization GetAuthorization() =>
            storageService.Get<TeslaAuthorization>(authorizationFileName);

        public void SaveAuthorization(TeslaAuthorization authorization) =>
            storageService.Save(authorizationFileName, authorization);

        public async Task<IEnumerable<TeslaVehicle>> GetVehiclesAsync(TeslaAuthorization authorization)
        {
            var result = await apiClient.GetVehiclesAsync(authorization);
            if (!string.IsNullOrEmpty(result.Error))
                return Enumerable.Empty<TeslaVehicle>();

            return result.Content?.Response;
        }

        public async Task<TeslaVehicle> GetVehicleAsync(TeslaAuthorization authorization, long vehicleId)
        {
            var result = await apiClient.GetVehicleAsync(authorization, vehicleId);
            if (!string.IsNullOrEmpty(result.Error))
                return null;

            return result.Content?.Response;
        }

        public async Task<TeslaVehicleData> GetVehicleDataAsync(TeslaAuthorization authorization, long vehicleId)
        {
            var result = await apiClient.GetVehicleDataAsync(authorization, vehicleId);
            if (!string.IsNullOrEmpty(result.Error))
                return null;

            return result.Content?.Response;
        }

        public async Task<TeslaVehicleDataChargeState> GetVehicleDataChargeStateAsync(TeslaAuthorization authorization, long vehicleId)
        {
            var result = await apiClient.GetVehicleDataChargeStateAsync(authorization, vehicleId);
            if (!string.IsNullOrEmpty(result.Error))
                return null;

            return result.Content?.Response;
        }

        public async Task<TeslaVehicleDataClimateState> GetVehicleDataClimateStateAsync(TeslaAuthorization authorization, long vehicleId)
        {
            var result = await apiClient.GetVehicleDataClimateStateAsync(authorization, vehicleId);
            if (!string.IsNullOrEmpty(result.Error))
                return null;

            return result.Content?.Response;
        }

        public async Task<TeslaVehicleDataDriveState> GetVehicleDataDriveStateAsync(TeslaAuthorization authorization, long vehicleId)
        {
            var result = await apiClient.GetVehicleDataDriveStateAsync(authorization, vehicleId);
            if (!string.IsNullOrEmpty(result.Error))
                return null;

            return result.Content?.Response;
        }

        public async Task<TeslaVehicleDataGuiSettings> GetVehicleDataGuiSettingsAsync(TeslaAuthorization authorization, long vehicleId)
        {
            var result = await apiClient.GetVehicleDataGuiSettingsAsync(authorization, vehicleId);
            if (!string.IsNullOrEmpty(result.Error))
                return null;

            return result.Content?.Response;
        }

        public async Task<TeslaVehicleDataVehicleState> GetVehicleDataVehicleStateAsync(TeslaAuthorization authorization, long vehicleId)
        {
            var result = await apiClient.GetVehicleDataVehicleStateAsync(authorization, vehicleId);
            if (!string.IsNullOrEmpty(result.Error))
                return null;

            return result.Content?.Response;
        }

        public async Task<TeslaVehicleDataVehicleConfig> GetVehicleDataVehicleConfigAsync(TeslaAuthorization authorization, long vehicleId)
        {
            var result = await apiClient.GetVehicleDataVehicleConfigAsync(authorization, vehicleId);
            if (!string.IsNullOrEmpty(result.Error))
                return null;

            return result.Content?.Response;
        }

        public async Task<bool?> GetVehicleMobileEnabledAsync(TeslaAuthorization authorization, long vehicleId)
        {
            var result = await apiClient.GetVehicleMobileEnabledAsync(authorization, vehicleId);
            if (!string.IsNullOrEmpty(result.Error))
                return null;

            return result.Content?.Response;
        }

        public async Task<TeslaVehicleNearbyChargingSites> GetVehicleNearbyChargingSitesAsync(TeslaAuthorization authorization, long vehicleId)
        {
            var result = await apiClient.GetVehicleNearbyChargingSitesAsync(authorization, vehicleId);
            if (!string.IsNullOrEmpty(result.Error))
                return null;

            return result.Content?.Response;
        }
    }
}
