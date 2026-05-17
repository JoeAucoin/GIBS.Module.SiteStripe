using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using Oqtane.Modules;

namespace GIBS.Module.SiteStripe.Repository
{
    public interface ICategoryRepository
    {
        IEnumerable<Models.Category> GetCategories(int ModuleId);
        IEnumerable<Models.Category> GetCategoriesBySiteId(int SiteId);
        Models.Category GetCategory(int CategoryId);
        Models.Category GetCategory(int CategoryId, bool tracking);
        Models.Category AddCategory(Models.Category Category);
        Models.Category UpdateCategory(Models.Category Category);
        void DeleteCategory(int CategoryId);
    }

    public class CategoryRepository : ICategoryRepository, ITransientService
    {
        private readonly IDbContextFactory<SiteStripeContext> _factory;

        public CategoryRepository(IDbContextFactory<SiteStripeContext> factory)
        {
            _factory = factory;
        }

        public IEnumerable<Models.Category> GetCategories(int ModuleId)
        {
            using var db = _factory.CreateDbContext();
            return db.Category.Where(item => item.ModuleId == ModuleId).ToList();
        }

        public IEnumerable<Models.Category> GetCategoriesBySiteId(int SiteId)
        {
            using var db = _factory.CreateDbContext();
            // Query categories that belong to modules in the specified site
            return db.Category.FromSqlInterpolated($@"
                SELECT DISTINCT c.* FROM GIBS_SiteStripe_Category c
                INNER JOIN [pf_Modules] m ON c.ModuleId = m.ModuleId
                WHERE m.SiteId = {SiteId}
                ORDER BY c.Name")
                .AsNoTracking()
                .ToList();
        }

        public Models.Category GetCategory(int CategoryId)
        {
            return GetCategory(CategoryId, true);
        }

        public Models.Category GetCategory(int CategoryId, bool tracking)
        {
            using var db = _factory.CreateDbContext();
            if (tracking)
            {
                return db.Category.Find(CategoryId);
            }
            else
            {
                return db.Category.AsNoTracking().FirstOrDefault(item => item.CategoryId == CategoryId);
            }
        }

        public Models.Category AddCategory(Models.Category Category)
        {
            using var db = _factory.CreateDbContext();
            db.Category.Add(Category);
            db.SaveChanges();
            return Category;
        }

        public Models.Category UpdateCategory(Models.Category Category)
        {
            using var db = _factory.CreateDbContext();
            db.Entry(Category).State = EntityState.Modified;
            db.SaveChanges();
            return Category;
        }

        public void DeleteCategory(int CategoryId)
        {
            using var db = _factory.CreateDbContext();
            var category = db.Category.Find(CategoryId);
            db.Category.Remove(category);
            db.SaveChanges();
        }
    }
}
