using Microsoft.AspNetCore.Routing;
using Nop.Core;
using Nop.Core.Domain.Cms;
using Nop.Core.Domain.Customers;
using Nop.Core.Domain.Security;
using Nop.Plugin.Misc.WhatsApp.Constant;
using Nop.Plugin.Misc.WhatsApp.Permission;
using Nop.Services.Cms;
using Nop.Services.Configuration;
using Nop.Services.Customers;
using Nop.Services.Localization;
using Nop.Services.Plugins;
using Nop.Services.Security;
using Nop.Web.Framework;
using Nop.Web.Framework.Infrastructure;
using Nop.Web.Framework.Menu;

namespace Nop.Plugin.Misc.CycleFlow
{
    public class WhatsAppPlugin : BasePlugin, IAdminMenuPlugin, IWidgetPlugin
    {
        #region Fields
        protected readonly IWebHelper _webHelper;
        private readonly ILocalizationService _localizationService;
        private readonly ILanguageService _languageService;
        protected readonly IPermissionService _permissionService;
        protected readonly ICustomerService _customerService;
        protected readonly WidgetSettings _widgetSettings;
        protected readonly ISettingService _settingService;
        #endregion
        #region Ctor
        public WhatsAppPlugin(
            IWebHelper webHelper,
            ILocalizationService localizationService,
            ILanguageService languageService,
            IPermissionService permissionService,
            ICustomerService customerService,
            WidgetSettings widgetSettings,
            ISettingService settingService
            )
        {
            _webHelper = webHelper;
            _localizationService = localizationService;
            _languageService = languageService;
            _permissionService = permissionService;
            _customerService = customerService;
            _widgetSettings = widgetSettings;
            _settingService = settingService;
        }
        #endregion
        #region Methods
        public bool HideInWidgetList => false;
        public string GetWidgetViewComponentName(string widgetZone)
        {
            

            return null;
        }

        public Task<IList<string>> GetWidgetZonesAsync()
        {
            return Task.FromResult(new List<string>()
            {

            } as IList<string>);
        }

        public override string GetConfigurationPageUrl()
        {
            return $"{_webHelper.GetStoreLocation()}Admin/WhatsAppPlugin/Configure";
        }
        public override async Task InstallAsync()
        {
            await _permissionService.InstallPermissionsAsync(new WhatsAppPluginPermissionProvider());
            if (!_widgetSettings.ActiveWidgetSystemNames.Contains(SystemDefaults.SYSTEM_NAME))
            {
                _widgetSettings.ActiveWidgetSystemNames.Add(SystemDefaults.SYSTEM_NAME);
                await _settingService.SaveSettingAsync(_widgetSettings);
            }
            await base.InstallAsync();
        }
        public override async Task UpdateAsync(string currentVersion, string targetVersion)
        {
            await UpdatePermissionDataAsync();
        }
        public override async Task UninstallAsync()
        {
            WhatsAppPluginPermissionProvider permissionProvider = new WhatsAppPluginPermissionProvider();

            foreach (var permation in permissionProvider.GetPermissions())
            {
                await DeleteRoleDataAsync(permation);
            }

            await _localizationService.DeleteLocaleResourceAsync("Admin.Plugin.Misc.WhatsApp");
            await _localizationService.DeleteLocaleResourceAsync("Nop.Plugin.Misc.WhatsApp");
            await base.UninstallAsync();
        }

        public async Task ManageSiteMapAsync(SiteMapNode rootNode)
        {
            var menueItem = new SiteMapNode()
            {
                SystemName = SystemDefaults.CYCLE_FLOW_SITE_MAP_NODE_SYSTEM_NAME,
                Title = _localizationService.GetResourceAsync("Nop.Plugin.Misc.WhatsApp.WhatsApp").Result,
                ControllerName = null,
                ActionName = null,
                IconClass = "fas fa-stream",
                Visible = true,
            };
            if (await _permissionService.AuthorizeAsync(WhatsAppPluginPermissionProvider.AccessToWhatsAppPluginMenu))
            {
                rootNode.ChildNodes.Add(menueItem);
            }
            
        }
        #endregion
        #region Utilites
        protected async Task DeleteRoleDataAsync(PermissionRecord permission)
        {

            var manageAccountingAccountPermission = (await _permissionService.GetAllPermissionRecordsAsync())
                                                    .FirstOrDefault(x => x.SystemName == permission.SystemName);
            if (manageAccountingAccountPermission != null)
            {
                var listMappingCustomerRolePermissionRecord = await _permissionService.GetMappingByPermissionRecordIdAsync(manageAccountingAccountPermission.Id);
                foreach (var mappingCustomerPermissionRecord in listMappingCustomerRolePermissionRecord)
                    await _permissionService.DeletePermissionRecordCustomerRoleMappingAsync(
                        mappingCustomerPermissionRecord.PermissionRecordId,
                        mappingCustomerPermissionRecord.CustomerRoleId);

                await _permissionService.DeletePermissionRecordAsync(manageAccountingAccountPermission);
            }

        }
        public async Task UpdatePermissionDataAsync()
        {
            var permissionProvider = new WhatsAppPluginPermissionProvider();

            var installedPermissions = await _permissionService.GetAllPermissionRecordsAsync();
            var defaultPermissionMapping = permissionProvider.GetDefaultPermissions();
            var roles = await _customerService.GetAllCustomerRolesAsync(showHidden: true);
            foreach (var permission in permissionProvider.GetPermissions())
            {
                if (!installedPermissions.Select(t => t.SystemName)?.Contains(permission.SystemName) ?? false)
                {
                    await _permissionService.InsertPermissionRecordAsync(permission);

                    foreach (var role in roles)
                    {
                        if (
                            defaultPermissionMapping.Select(t => t.systemRoleName).Contains(role.SystemName)
                            &&
                            (defaultPermissionMapping.Where(t => t.systemRoleName == role.SystemName)?.SelectMany(t => t.permissions.Select(t => t.SystemName))?.Contains(permission.SystemName) ?? false)
                            )
                        {
                            await _permissionService.InsertPermissionRecordCustomerRoleMappingAsync(new PermissionRecordCustomerRoleMapping { CustomerRoleId = role.Id, PermissionRecordId = permission.Id });
                        }
                    }
                }
            }
        }
      
        #endregion
    }
}
