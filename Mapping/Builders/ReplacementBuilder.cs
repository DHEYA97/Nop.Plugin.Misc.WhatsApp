using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Shipping;
using Nop.Core.Domain.Stores;
using Nop.Data.Extensions;
using Nop.Data.Mapping.Builders;
using Nop.Plugin.Misc.WhatsApp.Domain;


namespace Nop.Plugin.Misc.WhatsApp.Mapping.Builders
{
    public class ReplacementBuilder : NopEntityBuilder<Replacement>
    {
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(Replacement.Key)).AsString()
                .WithColumn(nameof(Replacement.Replace)).AsString()
                

                .WithColumn(nameof(Replacement.InsertedByUser)).AsInt32().Nullable()
                .WithColumn(nameof(Replacement.InsertionDate)).AsDateTime().Nullable()
                .WithColumn(nameof(Replacement.UpdatedByUser)).AsInt32().Nullable()
                .WithColumn(nameof(Replacement.UpdatingDate)).AsDateTime().Nullable();
        }
    }
}
