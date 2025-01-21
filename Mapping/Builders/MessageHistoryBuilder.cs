using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Customers;
using Nop.Data.Extensions;
using Nop.Data.Mapping.Builders;
using Nop.Plugin.Misc.WhatsApp.Domain;

namespace Nop.Plugin.Misc.CycleFlow.Mapping.Builders
{
    public class MessageHistoryBuilder : NopEntityBuilder<MessageHistory>
    {
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(MessageHistory.TemplateId)).AsInt32().ForeignKey<Template>(onDelete: System.Data.Rule.None)
                .WithColumn(nameof(MessageHistory.CustomerId)).AsInt32().ForeignKey<Customer>(onDelete: System.Data.Rule.None)
                .WithColumn(nameof(MessageHistory.Status)).AsBoolean()

                .WithColumn(nameof(MessageHistory.InsertedByUser)).AsInt32().Nullable()
                .WithColumn(nameof(MessageHistory.InsertionDate)).AsDateTime().Nullable()
                .WithColumn(nameof(MessageHistory.UpdatedByUser)).AsInt32().Nullable()
                .WithColumn(nameof(MessageHistory.UpdatingDate)).AsDateTime().Nullable();
        }
    }
}
