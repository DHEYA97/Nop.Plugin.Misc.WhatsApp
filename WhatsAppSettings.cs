using Nop.Core.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Plugin.Misc.WhatsApp
{
    public class WhatsAppSettings : ISettings
    {
        public string InstanceId { get; set; }
        public string Token { get; set; }
    }
}
