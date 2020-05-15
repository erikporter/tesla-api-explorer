using System;

namespace TeslaApiExplorer.Models
{
    public class TeslaApiClientAppSettings
    {
        public Uri BaseAddress { get; set; }

        public TimeSpan Timeout { get; set; }

        public TeslaApiClientUserAgentAppSettings UserAgent { get; set; }
    }
}
