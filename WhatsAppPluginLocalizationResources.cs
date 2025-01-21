using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Plugin.Misc.WhatsApp
{
    public static class WhatsAppPluginLocalizationResources
    {
        public static IDictionary<string, string> PluginResources(string LangCode)
        {
            switch (LangCode.ToLower())
            {
                case "en":
                    return PluginEnglishResources();
                case "ar":
                    return PluginArabicResources();

                default: return PluginEnglishResources();
            }
        }
        private static IDictionary<string, string> PluginEnglishResources()
        {
            return new Dictionary<string, string>
            {
                #region English
                
				#endregion
			};
        }

        private static IDictionary<string, string> PluginArabicResources()
        {
            return new Dictionary<string, string>
            {
                #region Arabic
                
                #endregion
            };
        }
    }
}
