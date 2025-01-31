﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nop.Core.Infrastructure;

namespace Nop.Plugin.Misc.WhatsApp.Infrastructure
{
    public class NopStartup : INopStartup
    {
        public int Order => 2000;

        public void Configure(IApplicationBuilder application)
        {
            
        }

        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<RazorViewEngineOptions>(options =>
            {
                options.ViewLocationExpanders.Add(new WhatsAppViewLocationExpander());
            });
            #region Factory
            
            #endregion

            #region Service
            
            #endregion

        }
    }
}
