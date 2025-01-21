using Microsoft.AspNetCore.Mvc;
using Nop.Core.Domain.Common;
using Nop.Core;
using Nop.Services.Common;
using Nop.Services.Configuration;
using Nop.Services.Customers;
using Nop.Services.Directory;
using Nop.Services.Localization;
using Nop.Services.Messages;
using Nop.Services.Security;
using Nop.Web.Areas.Admin.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nop.Plugin.Misc.WhatsApp.Permission;
using Nop.Plugin.Misc.WhatsApp.Models;
using Nop.Web.Areas.Admin.Infrastructure.Mapper.Extensions;

namespace Nop.Plugin.Misc.WhatsApp.Controllers
{
    public class WhatsAppPluginController : BaseAdminController
    {
        #region Fields

        private readonly IPermissionService _permissionService;
        private readonly ISettingService _settingService;
        private readonly IStoreContext _storeContext;
        private readonly ILocalizationService _localizationService;
        private readonly INotificationService _notificationService;


        #endregion

        #region Ctor

        public WhatsAppPluginController(
            IPermissionService permissionService,
            ISettingService settingService,
            IStoreContext storeContext,
            ILocalizationService localizationService,
            INotificationService notificationService)
        {
            _permissionService = permissionService;
            _settingService = settingService;
            _storeContext = storeContext;
            _localizationService = localizationService;
            _notificationService = notificationService;
        }

        #endregion

        #region methods

        public async Task<IActionResult> Configure()
        {
            if (!await _permissionService.AuthorizeAsync(WhatsAppPluginPermissionProvider.AccessToWhatsAppPluginMenu))
                return AccessDeniedView();

            var storeScope = await _storeContext.GetActiveStoreScopeConfigurationAsync();
            var settings = await _settingService.LoadSettingAsync<WhatsAppSettings>(storeScope);

            var model = settings.ToSettingsModel<ConfigurationModel>();
            model.ActiveStoreScopeConfiguration = storeScope;

            if (storeScope == 0)
                return View(model);

            model.InstanceId_OverrideForStore = await _settingService.SettingExistsAsync(settings, x => x.InstanceId, storeScope);
            model.Token_OverrideForStore = await _settingService.SettingExistsAsync(settings, x => x.Token, storeScope);

            return View(model);

        }

        [HttpPost]
        public async Task<IActionResult> Configure(ConfigurationModel model)
        {
            if (!await _permissionService.AuthorizeAsync(WhatsAppPluginPermissionProvider.AccessToWhatsAppPluginMenu))
                return AccessDeniedView();

            var storeScope = await _storeContext.GetActiveStoreScopeConfigurationAsync();
            var settings = await _settingService.LoadSettingAsync<WhatsAppSettings>(storeScope);
            settings = model.ToSettings(settings);

            await _settingService.SaveSettingOverridablePerStoreAsync(settings, x => x.InstanceId, model.InstanceId_OverrideForStore, storeScope, false);
            await _settingService.SaveSettingOverridablePerStoreAsync(settings, x => x.Token, model.Token_OverrideForStore, storeScope, false);

            await _settingService.ClearCacheAsync();
            _notificationService.SuccessNotification(await _localizationService.GetResourceAsync("Admin.Configuration.Updated"));
            return RedirectToAction("Configure");
        }


        #endregion
    }
}
