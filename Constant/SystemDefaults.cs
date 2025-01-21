using System.Collections.Generic;

namespace Nop.Plugin.Misc.WhatsApp.Constant
{   
    public class SystemDefaults
    {
        public const string SYSTEM_NAME = "Misc.WhatsApp";
        public static string PluginOutputDir => "Misc.WhatsApp";
        public static string CYCLE_FLOW_SITE_MAP_NODE_SYSTEM_NAME => "CycleFlow";
        public static string PluginOutputPath => $"~/Plugins/{PluginOutputDir}";
        public const string API_URL = "https://api.ultramsg.com/";
        public const string API_URL_Message = "/messages/chat";
    }
}