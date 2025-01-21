using Nop.Data.Mapping;
using Nop.Plugin.Misc.WhatsApp.Domain;
namespace Nop.Plugin.Misc.CycleFlow.Mapping
{
    public class NameCompatibility : INameCompatibility
    {
        public Dictionary<Type, string> TableNames => new Dictionary<Type, string>()
        {
            {typeof(Template), $"WH_{nameof(Template)}" },
            {typeof(Replacement), $"WH_{nameof(Replacement)}" },
            {typeof(BlockedUser), $"WH_{nameof(BlockedUser)}" },
            {typeof(MessageHistory), $"WH_{nameof(MessageHistory)}" },
        };

        public Dictionary<(Type, string), string> ColumnName => new Dictionary<(Type, string), string>();
    }
}
