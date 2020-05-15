using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TeslaApiExplorer.Models;
using TeslaApiExplorer.Services;

namespace TeslaApiExplorer.Pages
{
    public class VehicleNearbyChargingSitesModel : TeslaPageModel
    {
        private readonly TeslaService teslaService;

        public VehicleNearbyChargingSitesModel(TeslaService teslaService) : base(teslaService)
        {
            this.teslaService = teslaService;
        }

        [ViewData]
        public string Title { get; set; }

        public TeslaVehicleNearbyChargingSites VehicleNearbyChargingSites { get; set; }

        public async Task<IActionResult> OnGetAsync(long vehicleId)
        {
            var vehicleData = await teslaService.GetVehicleAsync(Authorization, vehicleId);

            if (vehicleData == null)
                return NotFound();

            VehicleNearbyChargingSites = await teslaService.GetVehicleNearbyChargingSitesAsync(Authorization, vehicleId);

            if (VehicleNearbyChargingSites == null)
                return NotFound();

            Title = $"Nearby Charging Sites - {vehicleData.DisplayName} - Vehicles";

            return Page();
        }
    }
}
