using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TeslaApiExplorer.Models;
using TeslaApiExplorer.Services;

namespace TeslaApiExplorer.Pages
{
    public class VehicleModel : TeslaPageModel
    {
        private readonly TeslaService teslaService;

        public VehicleModel(TeslaService teslaService) : base(teslaService)
        {
            this.teslaService = teslaService;
        }

        [ViewData]
        public string Title { get; set; }

        public TeslaVehicle Vehicle { get; set; }

        public async Task<IActionResult> OnGetAsync(long vehicleId)
        {
            Vehicle = await teslaService.GetVehicleAsync(Authorization, vehicleId);

            if (Vehicle == null)
                return NotFound();

            Title = $"{Vehicle.DisplayName} - Vehicles";

            return Page();
        }
    }
}