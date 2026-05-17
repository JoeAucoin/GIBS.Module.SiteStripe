using System.Collections.Generic;
using System.Threading.Tasks;

namespace GIBS.Module.SiteStripe.Services
{
    public interface ICategoryService
    {
        Task<List<Models.Category>> GetCategoriesAsync(int ModuleId);
        Task<List<Models.Category>> GetCategoriesBySiteIdAsync(int SiteId);

        Task<Models.Category> GetCategoryAsync(int CategoryId, int ModuleId);

        Task<Models.Category> AddCategoryAsync(Models.Category Category);

        Task<Models.Category> UpdateCategoryAsync(Models.Category Category);

        Task DeleteCategoryAsync(int CategoryId, int ModuleId);
    }
}
