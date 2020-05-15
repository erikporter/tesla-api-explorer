using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TeslaApiExplorer.Models;
using TeslaApiExplorer.Services;

namespace TeslaApiExplorer.Pages
{
    public class VehiclesModel : TeslaPageModel
    {
        private readonly TeslaService teslaService;

        public VehiclesModel(TeslaService teslaService) : base(teslaService)
        {
            this.teslaService = teslaService;
        }

        [ViewData]
        public string Title { get; set; }

        public IEnumerable<TeslaVehicle> Vehicles { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            Vehicles = await teslaService.GetVehiclesAsync(Authorization);

            Title = "Vehicles";

            return Page();
        }
    }
}
