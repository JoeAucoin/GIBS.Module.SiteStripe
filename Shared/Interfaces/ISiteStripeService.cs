using System.Collections.Generic;
using System.Threading.Tasks;

namespace GIBS.Module.SiteStripe.Services
{
    public interface ISiteStripeService 
    {
        Task<List<Models.SiteStripe>> GetSiteStripesAsync(int ModuleId);

        Task<Models.SiteStripe> GetSiteStripeAsync(int SiteStripeId, int ModuleId);

        Task<Models.SiteStripe> AddSiteStripeAsync(Models.SiteStripe SiteStripe);

        Task<Models.SiteStripe> UpdateSiteStripeAsync(Models.SiteStripe SiteStripe);

        Task DeleteSiteStripeAsync(int SiteStripeId, int ModuleId);
    }
}
