using FluentMigrator;
using Nop.Data.Extensions;
using Nop.Data.Migrations;
using Nop.Plugin.Misc.WhatsApp.Domain;


namespace Nop.Plugin.Misc.WhatsApp.Migrations
{
    [NopMigration("2025-01-17 00:00:00", "WhatsAppPlugin base schema", MigrationProcessType.Installation)]
    public class SchemaMigration : AutoReversingMigration
    {
        public override void Up()
        {
            Create.TableFor<Template>();
            Create.TableFor<Replacement>();
            Create.TableFor<BlockedUser>();
            Create.TableFor<MessageHistory>();
        }
    }
}
