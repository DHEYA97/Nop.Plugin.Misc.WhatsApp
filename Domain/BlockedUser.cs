using Nop.Plugin.Misc.WhatsApp.Domain;
namespace Nop.Plugin.Misc.WhatsApp.Domain
{
    public class BlockedUser : BaseWhatsAppEntity
    {
        public int TemplateId { get; set; }
        public int CustomerId { get; set; }
    }
}