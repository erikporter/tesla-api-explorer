using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TeslaApiExplorer.Pages
{
    public class IndexModel : PageModel
    {
        [ViewData]
        public string Title { get; set; }

        public IActionResult OnGet()
        {
            Title = "Home";

            return Page();
        }
    }
}
