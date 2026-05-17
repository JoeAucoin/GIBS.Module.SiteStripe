using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Oqtane.Services;
using Oqtane.Shared;

namespace GIBS.Module.SiteStripe.Services
{
    public class ClientCategoryService : ServiceBase, ICategoryService
    {
        public ClientCategoryService(HttpClient http, SiteState siteState) : base(http, siteState) { }

        private string Apiurl => CreateApiUrl("SiteStripeCategory");

        public async Task<List<Models.Category>> GetCategoriesAsync(int ModuleId)
        {
            return await GetJsonAsync<List<Models.Category>>(CreateAuthorizationPolicyUrl($"{Apiurl}?moduleid={ModuleId}", EntityNames.Module, ModuleId), Enumerable.Empty<Models.Category>().ToList());
        }

        public async Task<List<Models.Category>> GetCategoriesBySiteIdAsync(int SiteId)
        {
            return await GetJsonAsync<List<Models.Category>>(CreateAuthorizationPolicyUrl($"{Apiurl}/site/{SiteId}", EntityNames.Site, SiteId), Enumerable.Empty<Models.Category>().ToList());
        }

        public async Task<Models.Category> GetCategoryAsync(int CategoryId, int ModuleId)
        {
            return await GetJsonAsync<Models.Category>(CreateAuthorizationPolicyUrl($"{Apiurl}/{CategoryId}/{ModuleId}", EntityNames.Module, ModuleId));
        }

        public async Task<Models.Category> AddCategoryAsync(Models.Category Category)
        {
            return await PostJsonAsync<Models.Category>(CreateAuthorizationPolicyUrl($"{Apiurl}", EntityNames.Module, Category.ModuleId), Category);
        }

        public async Task<Models.Category> UpdateCategoryAsync(Models.Category Category)
        {
            return await PutJsonAsync<Models.Category>(CreateAuthorizationPolicyUrl($"{Apiurl}/{Category.CategoryId}", EntityNames.Module, Category.ModuleId), Category);
        }

        public async Task DeleteCategoryAsync(int CategoryId, int ModuleId)
        {
            await DeleteAsync(CreateAuthorizationPolicyUrl($"{Apiurl}/{CategoryId}/{ModuleId}", EntityNames.Module, ModuleId));
        }
    }
}
