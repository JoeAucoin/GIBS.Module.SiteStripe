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
        private const string _entityTableName = "GIBSSiteStripe";
        private readonly PrimaryKey<SiteStripeEntityBuilder> _primaryKey = new("PK_GIBSSiteStripe", x => x.SiteStripeId);
        private readonly ForeignKey<SiteStripeEntityBuilder> _moduleForeignKey = new("FK_GIBSSiteStripe_Module", x => x.ModuleId, "Module", "ModuleId", ReferentialAction.Cascade);

        public SiteStripeEntityBuilder(MigrationBuilder migrationBuilder, IDatabase database) : base(migrationBuilder, database)
        {
            EntityTableName = _entityTableName;
            PrimaryKey = _primaryKey;
            ForeignKeys.Add(_moduleForeignKey);
        }

        protected override SiteStripeEntityBuilder BuildTable(ColumnsBuilder table)
        {
            SiteStripeId = AddAutoIncrementColumn(table,"SiteStripeId");
            ModuleId = AddIntegerColumn(table,"ModuleId");
            Name = AddMaxStringColumn(table,"Name");
            AddAuditableColumns(table);
            return this;
        }

        public OperationBuilder<AddColumnOperation> SiteStripeId { get; set; }
        public OperationBuilder<AddColumnOperation> ModuleId { get; set; }
        public OperationBuilder<AddColumnOperation> Name { get; set; }
    }
}
