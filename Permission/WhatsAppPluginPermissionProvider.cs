using Nop.Core.Domain.Customers;
using Nop.Core.Domain.Security;
using Nop.Services.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Plugin.Misc.WhatsApp.Permission
{
    public partial class WhatsAppPluginPermissionProvider : IPermissionProvider
    {
        public static readonly PermissionRecord AccessToWhatsAppPluginMenu = new()
        {
            Name = "Access To WhatsApp Plugin Menu",
            SystemName = "AccessToWhatsAppPluginMenu",
            Category = "WhatsApp"
        };
        
        public virtual IEnumerable<PermissionRecord> GetPermissions()
        {
            return new[]
            {
                AccessToWhatsAppPluginMenu,
            };
        }
        /// <summary>
        /// Get default permissions
        /// </summary>
        /// <returns>Permissions</returns>
        public virtual HashSet<(string systemRoleName, PermissionRecord[] permissions)> GetDefaultPermissions()
        {
            return new() { (NopCustomerDefaults.AdministratorsRoleName, GetPermissions().ToArray()) };
        }
    }
}
