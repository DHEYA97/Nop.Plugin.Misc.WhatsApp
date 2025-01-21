using FluentMigrator;
using Nop.Core.Infrastructure;
using Nop.Data;
using Nop.Data.Extensions;
using Nop.Data.Migrations;
using Nop.Plugin.Misc.WhatsApp;
using Nop.Services.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Plugin.Misc.WhatsApp.Migrations
{
    [NopMigration("2025-01-18 00:00:00", "WhatsAppPlugin LocalizationResource", MigrationProcessType.Installation)]
    public class InstallLocalizationResourceMigration : MigrationBase
    {
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
