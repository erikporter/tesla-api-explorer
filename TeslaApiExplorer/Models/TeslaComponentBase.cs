using Microsoft.AspNetCore.Components;
using System;
using System.Net;
using TeslaApiExplorer.Services;

namespace TeslaApiExplorer.Models
{
    public class TeslaComponentBase : ComponentBase
    {
        [Inject]
        protected NavigationManager NavigationManager { get; set; }

        [Inject]
        public TeslaService TeslaService { get; private set; }

        public TeslaAuthorization Authorization { get; private set; }

        protected override void OnInitialized()
        {
            var authorization = TeslaService.GetAuthorization();

            if (authorization == null)
                NavigationManager.NavigateTo($"/login?redirect={WebUtility.UrlEncode(new Uri(NavigationManager.Uri).PathAndQuery)}");
            else
                Authorization = authorization;

            base.OnInitialized();
        }
    }
}
