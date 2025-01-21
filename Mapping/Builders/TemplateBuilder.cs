using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Customers;
using Nop.Core.Domain.Media;
using Nop.Core.Domain.Orders;
using Nop.Core.Domain.Stores;
using Nop.Data.Extensions;
using Nop.Data.Mapping.Builders;
using Nop.Plugin.Misc.WhatsApp.Domain;

namespace Nop.Plugin.Misc.WhatsApp.Mapping.Builders
{
    internal class TemplateBuilder : NopEntityBuilder<Template>
    {
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(Template.Name)).AsString()
                .WithColumn(nameof(Template.Body)).AsString()
                .WithColumn(nameof(Template.Active)).AsString()
                
                .WithColumn(nameof(Template.InsertedByUser)).AsInt32().Nullable()
                .WithColumn(nameof(Template.InsertionDate)).AsDateTime().Nullable()
                .WithColumn(nameof(Template.UpdatedByUser)).AsInt32().Nullable()
                .WithColumn(nameof(Template.UpdatingDate)).AsDateTime().Nullable();
        }
    }
}
