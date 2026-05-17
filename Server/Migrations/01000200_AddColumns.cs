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
    [Migration("GIBS.Module.SiteStripe.01.00.02.00")]
    public class AddColumns : MultiDatabaseMigration
    {
        public AddColumns(IDatabase database) : base(database)
        {
        }

        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AddColumn<int>(
               name: "SiteId",
               table: "GIBS_SiteStripe",
               type: "int",
               nullable: false,
               defaultValue: 1);

            //CategoryId
            migrationBuilder.AddColumn<int>(
            name: "CategoryId",
            table: "GIBS_SiteStripe",
            type: "int",
            nullable: false,
            defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SiteId",
                table: "GIBS_SiteStripe");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "GIBS_SiteStripe");
        }
    }
}
