using Microsoft.AspNetCore.Builder; 
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Oqtane.Infrastructure;
using GIBS.Module.SiteStripe.Repository;
using GIBS.Module.SiteStripe.Services;

namespace GIBS.Module.SiteStripe.Startup
{
    public class ServerStartup : IServerStartup
    {
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // not implemented
        }

        public void ConfigureMvc(IMvcBuilder mvcBuilder)
        {
            // not implemented
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<ISiteStripeService, ServerSiteStripeService>();
            services.AddDbContextFactory<SiteStripeContext>(opt => { }, ServiceLifetime.Transient);
        }
    }
}
