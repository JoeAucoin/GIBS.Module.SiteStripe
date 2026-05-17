using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using Oqtane.Modules;

namespace GIBS.Module.SiteStripe.Repository
{
    public interface ISiteStripeRepository
    {
        IEnumerable<Models.SiteStripe> GetSiteStripes(int ModuleId);
        IEnumerable<Models.SiteStripe> GetSiteStripesBySiteId(int SiteId);
        Models.SiteStripe GetSiteStripe(int SiteStripeId);
        Models.SiteStripe GetSiteStripe(int SiteStripeId, bool tracking);
        Models.SiteStripe AddSiteStripe(Models.SiteStripe SiteStripe);
        Models.SiteStripe UpdateSiteStripe(Models.SiteStripe SiteStripe);
        void DeleteSiteStripe(int SiteStripeId);
    }

    public class SiteStripeRepository : ISiteStripeRepository, ITransientService
    {
        private readonly IDbContextFactory<SiteStripeContext> _factory;

        public SiteStripeRepository(IDbContextFactory<SiteStripeContext> factory)
        {
            _factory = factory;
        }

        public IEnumerable<Models.SiteStripe> GetSiteStripes(int ModuleId)
        {
            using var db = _factory.CreateDbContext();
            return (from siteStripe in db.SiteStripe
                    join category in db.Category on siteStripe.CategoryId equals category.CategoryId into categories
                    from category in categories.DefaultIfEmpty()
                    where siteStripe.ModuleId == ModuleId
                    select new Models.SiteStripe
                    {
                        SiteStripeId = siteStripe.SiteStripeId,
                        ModuleId = siteStripe.ModuleId,
                        SiteId = siteStripe.SiteId,
                        Name = siteStripe.Name,
                        ASIN = siteStripe.ASIN,
                        AffiliateURL = siteStripe.AffiliateURL,
                        ImageURL = siteStripe.ImageURL,
                        PricePoint = siteStripe.PricePoint,
                        ProductCategory = siteStripe.ProductCategory,
                        CategoryId = siteStripe.CategoryId,
                        IsPrimeEligible = siteStripe.IsPrimeEligible,
                        IsActive = siteStripe.IsActive,
                        DisplayTemplate = siteStripe.DisplayTemplate,
                        OpenInNewTab = siteStripe.OpenInNewTab,
                        RelAttribute = siteStripe.RelAttribute,
                        RawHTMLEmbed = siteStripe.RawHTMLEmbed,
                        VideoURL = siteStripe.VideoURL,
                        CreatedBy = siteStripe.CreatedBy,
                        CreatedOn = siteStripe.CreatedOn,
                        ModifiedBy = siteStripe.ModifiedBy,
                        ModifiedOn = siteStripe.ModifiedOn,
                        CategoryName = category != null ? category.Name : string.Empty
                    }).ToList();
        }

        public IEnumerable<Models.SiteStripe> GetSiteStripesBySiteId(int SiteId)
        {
            using var db = _factory.CreateDbContext();
            return (from siteStripe in db.SiteStripe
                    join category in db.Category on siteStripe.CategoryId equals category.CategoryId into categories
                    from category in categories.DefaultIfEmpty()
                    where siteStripe.SiteId == SiteId
                    select new Models.SiteStripe
                    {
                        SiteStripeId = siteStripe.SiteStripeId,
                        ModuleId = siteStripe.ModuleId,
                        SiteId = siteStripe.SiteId,
                        Name = siteStripe.Name,
                        ASIN = siteStripe.ASIN,
                        AffiliateURL = siteStripe.AffiliateURL,
                        ImageURL = siteStripe.ImageURL,
                        PricePoint = siteStripe.PricePoint,
                        ProductCategory = siteStripe.ProductCategory,
                        CategoryId = siteStripe.CategoryId,
                        IsPrimeEligible = siteStripe.IsPrimeEligible,
                        IsActive = siteStripe.IsActive,
                        DisplayTemplate = siteStripe.DisplayTemplate,
                        OpenInNewTab = siteStripe.OpenInNewTab,
                        RelAttribute = siteStripe.RelAttribute,
                        RawHTMLEmbed = siteStripe.RawHTMLEmbed,
                        VideoURL = siteStripe.VideoURL,
                        CreatedBy = siteStripe.CreatedBy,
                        CreatedOn = siteStripe.CreatedOn,
                        ModifiedBy = siteStripe.ModifiedBy,
                        ModifiedOn = siteStripe.ModifiedOn,
                        CategoryName = category != null ? category.Name : string.Empty
                    }).ToList();
        }


        public Models.SiteStripe GetSiteStripe(int SiteStripeId)
        {
            return GetSiteStripe(SiteStripeId, true);
        }

        public Models.SiteStripe GetSiteStripe(int SiteStripeId, bool tracking)
        {
            using var db = _factory.CreateDbContext();
            Models.SiteStripe siteStripe;
            if (tracking)
            {
                siteStripe = db.SiteStripe.Find(SiteStripeId);
            }
            else
            {
                siteStripe = db.SiteStripe.AsNoTracking().FirstOrDefault(item => item.SiteStripeId == SiteStripeId);
            }

            if (siteStripe != null)
            {
                siteStripe.CategoryName = db.Category
                    .Where(item => item.CategoryId == siteStripe.CategoryId)
                    .Select(item => item.Name)
                    .FirstOrDefault() ?? string.Empty;
            }

            return siteStripe;
        }

        public Models.SiteStripe AddSiteStripe(Models.SiteStripe SiteStripe)
        {
            using var db = _factory.CreateDbContext();
            db.SiteStripe.Add(SiteStripe);
            db.SaveChanges();
            return SiteStripe;
        }

        public Models.SiteStripe UpdateSiteStripe(Models.SiteStripe SiteStripe)
        {
            using var db = _factory.CreateDbContext();
            db.Entry(SiteStripe).State = EntityState.Modified;
            db.SaveChanges();
            return SiteStripe;
        }

        public void DeleteSiteStripe(int SiteStripeId)
        {
            using var db = _factory.CreateDbContext();
            Models.SiteStripe SiteStripe = db.SiteStripe.Find(SiteStripeId);
            db.SiteStripe.Remove(SiteStripe);
            db.SaveChanges();
        }
    }
}
