﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Razor;
using Nop.Core.Infrastructure;
using Nop.Web.Framework.Themes;
using Nop.Web.Framework;
using Nop.Plugin.Misc.WhatsApp.Constant;


namespace Nop.Plugin.Misc.WhatsApp.Infrastructure
{
    public class WhatsAppViewLocationExpander : IViewLocationExpander
    {
        private static string WhatsApp_System_OutputDir => SystemDefaults.PluginOutputDir;
        private const string THEME_KEY = "nop.themename";

        public void PopulateValues(ViewLocationExpanderContext context)
        {
            //no need to add the themeable view locations at all as the administration should not be themeable anyway
            if (context.AreaName?.Equals(AreaNames.Admin) ?? false)
                return;

            context.Values[THEME_KEY] = EngineContext.Current.Resolve<IThemeContext>().GetWorkingThemeNameAsync().Result;
        }


        public IEnumerable<string> ExpandViewLocations(ViewLocationExpanderContext context, IEnumerable<string> viewLocations)
        {
            if (context.AreaName != "Admin")
            {
                if (context.Values.TryGetValue(THEME_KEY, out string theme))
                {
                    viewLocations = new[] {
                        $"/Plugins/{WhatsApp_System_OutputDir}/Views/{{1}}/{{0}}.cshtml",
                        $"/Plugins/{WhatsApp_System_OutputDir}/Views/Shared/{{0}}.cshtml",
                        $"/Plugins/{WhatsApp_System_OutputDir}/Themes/{theme}/Views/{{1}}/{{0}}.cshtml",
                        $"/Plugins/{WhatsApp_System_OutputDir}/Themes/{theme}/Views/Shared/{{0}}.cshtml",
                    }
                        .Concat(viewLocations);
                }
            }
            else if (context.AreaName == "Admin")
            {
                viewLocations = new[] {
                        $"/Plugins/{WhatsApp_System_OutputDir}/Areas/Admin/Views/{{1}}/{{0}}.cshtml",
                        $"/Plugins/{WhatsApp_System_OutputDir}/Areas/Admin/Views/Shared/{{0}}.cshtml",
                        $"/Plugins/{WhatsApp_System_OutputDir}/Views/{{1}}/{{0}}.cshtml",
                        $"/Plugins/{WhatsApp_System_OutputDir}/Views/Shared/{{0}}.cshtml",
                    }
                    .Concat(viewLocations);
            }
            return viewLocations;
        }
    }
}
