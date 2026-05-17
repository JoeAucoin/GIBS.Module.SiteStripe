//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace GIBS.Module.SiteStripe.Server.Migrations
//{
//    internal class AddSiteIdToCategory
//    {
//    }
//}

//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace GIBS.Module.SiteStripe.Server.Migrations
//{
//    internal class _01000100_AddVideoColumn
//    {
//    }
//}
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Oqtane.Databases.Interfaces;
using Oqtane.Migrations;
using GIBS.Module.SiteStripe.Repository;

namespace GIBS.Module.SiteStripe.Migrations
{
    [DbContext(typeof(SiteStripeContext))]
    [Migration("GIBS.Module.SiteStripe.01.00.03.00")]
    public class AddSiteIdToCategory : MultiDatabaseMigration
    {
        public AddSiteIdToCategory(IDatabase database) : base(database)
        {
        }

        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AddColumn<int>(
               name: "SiteId",
               table: "GIBS_SiteStripe_Category",
               type: "int",
               nullable: false,
               defaultValue: 1);

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SiteId",
                table: "GIBS_SiteStripe_Category");

         
        }
    }
}
