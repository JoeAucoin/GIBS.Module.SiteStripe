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
    [Migration("GIBS.Module.SiteStripe.01.00.01.00")]
    public class AddVideoColumn : MultiDatabaseMigration
    {
        public AddVideoColumn(IDatabase database) : base(database)
        {
        }

        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AddColumn<string>(
               name: "VideoURL",
               table: "GIBS_SiteStripe",
               type: "nvarchar(max)",
               nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VideoURL",
                table: "GIBS_SiteStripe");

        }
    }
}
