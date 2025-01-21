using Nop.Core;
using Nop.Core.Domain.Common;
using Nop.Core.Domain.Localization;
using Nop.Plugin.Misc.WhatsApp.Domain;

namespace Nop.Plugin.Misc.WhatsApp.Domain
{
    public class MessageHistory : BaseWhatsAppEntity
    {
        public int TemplateId { get; set; }
        public int CustomerId { get; set; }
        public bool Status { get; set; }
    }
}