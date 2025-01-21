using Nop.Data.Migrations;
using FluentMigrator;
using Nop.Core;
using Nop.Data.Mapping;
using Nop.Core.Infrastructure;
using Nop.Data;
using Nop.Services.Localization;
using Nop.Plugin.Misc.WhatsApp;


namespace Nop.Plugin.Misc.WhatsApp.Migrations
{
    [NopMigration("2025-01-19 00:00:00", "WhatsAppPlugin Update Table", MigrationProcessType.Update)]
    public class UpdateTableMigration : Migration
    {
        public static string TableName<T>() where T : BaseEntity
        {
            return NameCompatibilityManager.GetTableName(typeof(T));
        }
        public override void Down()
        {
            
        }

        public async override void Up()
        {
            if (!DataSettingsManager.IsDatabaseInstalled())
                return;

            var localizationService = EngineContext.Current.Resolve<ILocalizationService>();

            var languageService = EngineContext.Current.Resolve<ILanguageService>();


            var lang_list = await languageService.GetAllLanguagesAsync();


            foreach (var lang in lang_list)
            {
                await localizationService.AddOrUpdateLocaleResourceAsync(WhatsAppPluginLocalizationResources.PluginResources(lang.UniqueSeoCode), languageId: lang.Id);
            }
        }
    }
}
