using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Oqtane.Databases.Interfaces;
using Oqtane.Migrations;
using GIBS.Module.SiteStripe.Migrations.EntityBuilders;
using GIBS.Module.SiteStripe.Repository;

namespace GIBS.Module.SiteStripe.Migrations
{
    [DbContext(typeof(SiteStripeContext))]
    [Migration("GIBS.Module.SiteStripe.01.00.04.00")]
    public class RemoveCategoryNameUniqueIndex : MultiDatabaseMigration
    {
        public RemoveCategoryNameUniqueIndex(IDatabase database) : base(database)
        {
        }

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var categoryEntityBuilder = new CategoryEntityBuilder(migrationBuilder, ActiveDatabase);
            categoryEntityBuilder.DropIndex("IX_GIBSRecipe_Category_Name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var categoryEntityBuilder = new CategoryEntityBuilder(migrationBuilder, ActiveDatabase);
            categoryEntityBuilder.AddIndex("IX_GIBSRecipe_Category_Name", "Name", true);
        }
    }
}
