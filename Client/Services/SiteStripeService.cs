using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Oqtane.Services;
using Oqtane.Shared;

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

    public class SiteStripeService : ServiceBase, ISiteStripeService
    {
        public SiteStripeService(HttpClient http, SiteState siteState) : base(http, siteState) { }

        private string Apiurl => CreateApiUrl("SiteStripe");

        public async Task<List<Models.SiteStripe>> GetSiteStripesAsync(int ModuleId)
        {
            List<Models.SiteStripe> SiteStripes = await GetJsonAsync<List<Models.SiteStripe>>(CreateAuthorizationPolicyUrl($"{Apiurl}?moduleid={ModuleId}", EntityNames.Module, ModuleId), Enumerable.Empty<Models.SiteStripe>().ToList());
            return SiteStripes.OrderBy(item => item.Name).ToList();
        }

        public async Task<Models.SiteStripe> GetSiteStripeAsync(int SiteStripeId, int ModuleId)
        {
            return await GetJsonAsync<Models.SiteStripe>(CreateAuthorizationPolicyUrl($"{Apiurl}/{SiteStripeId}/{ModuleId}", EntityNames.Module, ModuleId));
        }

        public async Task<Models.SiteStripe> AddSiteStripeAsync(Models.SiteStripe SiteStripe)
        {
            return await PostJsonAsync<Models.SiteStripe>(CreateAuthorizationPolicyUrl($"{Apiurl}", EntityNames.Module, SiteStripe.ModuleId), SiteStripe);
        }

        public async Task<Models.SiteStripe> UpdateSiteStripeAsync(Models.SiteStripe SiteStripe)
        {
            return await PutJsonAsync<Models.SiteStripe>(CreateAuthorizationPolicyUrl($"{Apiurl}/{SiteStripe.SiteStripeId}", EntityNames.Module, SiteStripe.ModuleId), SiteStripe);
        }

        public async Task DeleteSiteStripeAsync(int SiteStripeId, int ModuleId)
        {
            await DeleteAsync(CreateAuthorizationPolicyUrl($"{Apiurl}/{SiteStripeId}/{ModuleId}", EntityNames.Module, ModuleId));
        }
    }
}
