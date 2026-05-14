using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using Oqtane.Modules;

namespace GIBS.Module.SiteStripe.Repository
{
    public interface ISiteStripeRepository
    {
        IEnumerable<Models.SiteStripe> GetSiteStripes(int ModuleId);
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
            return db.SiteStripe.Where(item => item.ModuleId == ModuleId).ToList();
        }

        public Models.SiteStripe GetSiteStripe(int SiteStripeId)
        {
            return GetSiteStripe(SiteStripeId, true);
        }

        public Models.SiteStripe GetSiteStripe(int SiteStripeId, bool tracking)
        {
            using var db = _factory.CreateDbContext();
            if (tracking)
            {
                return db.SiteStripe.Find(SiteStripeId);
            }
            else
            {
                return db.SiteStripe.AsNoTracking().FirstOrDefault(item => item.SiteStripeId == SiteStripeId);
            }
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
