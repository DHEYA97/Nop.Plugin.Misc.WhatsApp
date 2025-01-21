using Nop.Core;
using Nop.Plugin.Misc.WhatsApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Plugin.Misc.WhatsApp.Domain
{
    public class Template : BaseWhatsAppEntity
    {
        public string Name { get; set; }
        public string Body { get; set; }
        public bool Active { get; set; }
    }
}
