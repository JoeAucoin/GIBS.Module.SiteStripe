using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.EntityFrameworkCore.Migrations.Operations.Builders;
using Oqtane.Databases.Interfaces;
using Oqtane.Migrations;
using Oqtane.Migrations.EntityBuilders;

namespace GIBS.Module.SiteStripe.Migrations.EntityBuilders
{
    public class SiteStripeEntityBuilder : AuditableBaseEntityBuilder<SiteStripeEntityBuilder>
    {
        private const string _entityTableName = "GIBS_SiteStripe";
        private readonly PrimaryKey<SiteStripeEntityBuilder> _primaryKey = new("PK_GIBS_SiteStripe", x => x.SiteStripeId);
        private readonly ForeignKey<SiteStripeEntityBuilder> _moduleForeignKey = new("FK_GIBS_SiteStripe_Module", x => x.ModuleId, "Module", "ModuleId", ReferentialAction.Cascade);

        public SiteStripeEntityBuilder(MigrationBuilder migrationBuilder, IDatabase database) : base(migrationBuilder, database)
        {
            EntityTableName = _entityTableName;
            PrimaryKey = _primaryKey;
            ForeignKeys.Add(_moduleForeignKey);
        }

        protected override SiteStripeEntityBuilder BuildTable(ColumnsBuilder table)
        {
            SiteStripeId = AddAutoIncrementColumn(table, "SiteStripeId");
            ModuleId = AddIntegerColumn(table, "ModuleId");
            Name = AddMaxStringColumn(table, "Name");
            ASIN = AddStringColumn(table, "ASIN", 10, true);
            AffiliateURL = AddMaxStringColumn(table, "AffiliateURL", true);
            ImageURL = AddMaxStringColumn(table, "ImageURL", true);
            PricePoint = AddDecimalColumn(table, "PricePoint", 18, 2, true);
            ProductCategory = AddStringColumn(table, "ProductCategory", 250, true);
            IsPrimeEligible = AddBooleanColumn(table, "IsPrimeEligible");
            IsActive = AddBooleanColumn(table, "IsActive");
            DisplayTemplate = AddStringColumn(table, "DisplayTemplate", 50, true);
            OpenInNewTab = AddBooleanColumn(table, "OpenInNewTab");
            RelAttribute = AddStringColumn(table, "RelAttribute", 50, true);
            RawHTMLEmbed = AddMaxStringColumn(table, "RawHTMLEmbed", true);
            AddAuditableColumns(table);
            return this;
        }

        public OperationBuilder<AddColumnOperation> SiteStripeId { get; set; }
        public OperationBuilder<AddColumnOperation> ModuleId { get; set; }
        public OperationBuilder<AddColumnOperation> Name { get; set; }
        public OperationBuilder<AddColumnOperation> ASIN { get; set; }
        public OperationBuilder<AddColumnOperation> AffiliateURL { get; set; }
        public OperationBuilder<AddColumnOperation> ImageURL { get; set; }
        public OperationBuilder<AddColumnOperation> PricePoint { get; set; }
        public OperationBuilder<AddColumnOperation> ProductCategory { get; set; }
        public OperationBuilder<AddColumnOperation> IsPrimeEligible { get; set; }
        public OperationBuilder<AddColumnOperation> IsActive { get; set; }
        public OperationBuilder<AddColumnOperation> DisplayTemplate { get; set; }
        public OperationBuilder<AddColumnOperation> OpenInNewTab { get; set; }
        public OperationBuilder<AddColumnOperation> RelAttribute { get; set; }
        public OperationBuilder<AddColumnOperation> RawHTMLEmbed { get; set; }
    }
}
