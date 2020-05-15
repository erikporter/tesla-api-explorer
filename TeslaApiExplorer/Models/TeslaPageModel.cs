using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TeslaApiExplorer.Services;

namespace TeslaApiExplorer.Models
{
    public class TeslaPageModel : PageModel
    {
        private readonly TeslaService teslaService;

        public TeslaPageModel(TeslaService teslaService)
        {
            this.teslaService = teslaService;
        }

        public TeslaAuthorization Authorization { get; private set; }

        public override void OnPageHandlerExecuting(PageHandlerExecutingContext context)
        {
            var authorization = teslaService.GetAuthorizationAsync().Result;
            if (authorization == null)
                context.Result = new RedirectToPageResult("/Login", new { redirect = context.HttpContext.Request.Path });
            else
            {
                Authorization = authorization;
                base.OnPageHandlerExecuting(context);
            }
        }
    }
}
