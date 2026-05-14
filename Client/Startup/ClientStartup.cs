using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using Oqtane.Services;
using GIBS.Module.SiteStripe.Services;

namespace GIBS.Module.SiteStripe.Startup
{
    public class ClientStartup : IClientStartup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            if (!services.Any(s => s.ServiceType == typeof(ISiteStripeService)))
            {
                services.AddScoped<ISiteStripeService, ClientSiteStripeService>();
            }
        }
    }
}
