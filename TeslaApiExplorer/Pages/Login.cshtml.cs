using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using TeslaApiExplorer.Models;
using TeslaApiExplorer.Services;

namespace TeslaApiExplorer.Pages
{
    public class LoginModel : PageModel
    {
        private readonly TeslaService teslaService;

        public LoginModel(TeslaService teslaService)
        {
            this.teslaService = teslaService;
        }

        [BindProperty]
        public LoginInfo LoginInfo { get; set; }

        public async Task<IActionResult> OnPostAsync(string redirect)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var authorization = await teslaService.GetAuthorizationAsync(LoginInfo.Email, LoginInfo.Password);
            if (authorization == null)
            {
                return Page();
            }

            await teslaService.SaveAuthorizationAsync(authorization);

            return Redirect(redirect);
        }
    }
}
