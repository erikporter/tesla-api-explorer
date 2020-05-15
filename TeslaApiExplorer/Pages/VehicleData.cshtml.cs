using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TeslaApiExplorer.Models;
using TeslaApiExplorer.Services;

namespace TeslaApiExplorer.Pages
{
    public class VehicleDataModel : TeslaPageModel
    {
        private readonly TeslaService teslaService;

        public VehicleDataModel(TeslaService teslaService) : base(teslaService)
        {
            this.teslaService = teslaService;
        }

        [ViewData]
        public string Title { get; set; }

        public TeslaVehicleData VehicleData { get; set; }

        public string MobileEnabled { get; set; }

        public async Task<IActionResult> OnGetAsync(long vehicleId)
        {
            VehicleData = await teslaService.GetVehicleDataAsync(Authorization, vehicleId);

            if (VehicleData == null)
                return NotFound();

            var mobileEnabled = await teslaService.GetVehicleMobileEnabledAsync(Authorization, vehicleId);
            if (mobileEnabled == null)
                MobileEnabled = "Unknown";
            else
                if (mobileEnabled.Value)
                    MobileEnabled = "Yes";
                else
                    MobileEnabled = "No";

            Title = $"Data - {VehicleData.DisplayName} - Vehicles";

            return Page();
        }
    }
}
