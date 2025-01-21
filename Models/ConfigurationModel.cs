using Nop.Web.Framework.Models;
using Nop.Web.Framework.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Plugin.Misc.WhatsApp.Models
{
    public record ConfigurationModel : BaseNopModel, ISettingsModel
    {
        public int ActiveStoreScopeConfiguration { get; set; }

        [NopResourceDisplayName("Admin.Plugin.Misc.WhatsApp.Configuration.Fields.InstanceId")]
        public string InstanceId { get; set; }
        public bool InstanceId_OverrideForStore { get; set; }

        [NopResourceDisplayName("Admin.Plugin.Misc.WhatsApp.Configuration.Fields.Token")]
        public string Token { get; set; }
        public bool Token_OverrideForStore { get; set; }
    }
}
