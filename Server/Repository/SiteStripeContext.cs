using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Oqtane.Modules;
using Oqtane.Repository;
using Oqtane.Infrastructure;
using Oqtane.Repository.Databases.Interfaces;

namespace GIBS.Module.SiteStripe.Repository
{
    public class SiteStripeContext : DBContextBase, ITransientService, IMultiDatabase
    {
        public virtual DbSet<Models.SiteStripe> SiteStripe { get; set; }
        public virtual DbSet<Models.Category> Category { get; set; }

        public SiteStripeContext(IDBContextDependencies DBContextDependencies) : base(DBContextDependencies)
        {
            // ContextBase handles multi-tenant database connections
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Models.SiteStripe>().ToTable(ActiveDatabase.RewriteName("GIBS_SiteStripe"));
            builder.Entity<Models.Category>().ToTable(ActiveDatabase.RewriteName("GIBS_SiteStripe_Category"));
        }
    }
}
