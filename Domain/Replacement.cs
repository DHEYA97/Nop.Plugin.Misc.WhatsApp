using Nop.Core;
using Nop.Plugin.Misc.WhatsApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Plugin.Misc.WhatsApp.Domain
{
    public class Replacement : BaseWhatsAppEntity
    {
        public string Key { get; set; }
        public string Replace { get; set; }
    }
}
