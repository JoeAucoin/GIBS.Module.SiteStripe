using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Oqtane.Databases.Interfaces;
using Oqtane.Migrations;
using GIBS.Module.SiteStripe.Migrations.EntityBuilders;
using GIBS.Module.SiteStripe.Repository;

namespace GIBS.Module.SiteStripe.Migrations
{
    [DbContext(typeof(SiteStripeContext))]
    [Migration("GIBS.Module.SiteStripe.01.00.00.00")]
    public class InitializeModule : MultiDatabaseMigration
    {
        public InitializeModule(IDatabase database) : base(database)
        {
        }

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var entityBuilder = new SiteStripeEntityBuilder(migrationBuilder, ActiveDatabase);
            entityBuilder.Create();

            var categoryEntityBuilder = new CategoryEntityBuilder(migrationBuilder, ActiveDatabase);
            categoryEntityBuilder.Create();
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var entityBuilder = new SiteStripeEntityBuilder(migrationBuilder, ActiveDatabase);
            entityBuilder.Drop();

            var categoryEntityBuilder = new CategoryEntityBuilder(migrationBuilder, ActiveDatabase);
            categoryEntityBuilder.Drop();
        }
    }
}
