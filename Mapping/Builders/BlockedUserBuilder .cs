using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Customers;
using Nop.Core.Domain.Shipping;
using Nop.Core.Domain.Stores;
using Nop.Data.Extensions;
using Nop.Data.Mapping.Builders;
using Nop.Plugin.Misc.WhatsApp.Domain;
using StackExchange.Redis;

namespace Nop.Plugin.Misc.CycleFlow.Mapping.Builders
{
    public class BlockedUserBuilder : NopEntityBuilder<BlockedUser>
    {
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(BlockedUser.TemplateId)).AsInt32().ForeignKey<Template>(onDelete: System.Data.Rule.None)
                .WithColumn(nameof(BlockedUser.CustomerId)).AsInt32().ForeignKey<Customer>(onDelete: System.Data.Rule.None)

                .WithColumn(nameof(BlockedUser.InsertedByUser)).AsInt32().Nullable()
                .WithColumn(nameof(BlockedUser.InsertionDate)).AsDateTime().Nullable()
                .WithColumn(nameof(BlockedUser.UpdatedByUser)).AsInt32().Nullable()
                .WithColumn(nameof(BlockedUser.UpdatingDate)).AsDateTime().Nullable();
        }
    }
}
