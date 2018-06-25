using Microsoft.Extensions.Configuration;
using CoreSampleApp.Business.SimpleInjector;
using CoreSampleApp.Utilities.SimpleInjector;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CoreSampleApp.SimpleInjector
{
    public static class CoreSampleAppInjectorModule
    {
        public static void LoadTypes(Container container)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            container.Register<IConfiguration>(() => configuration);

            SimpleInjectorAccessor.Load(CoreSampleAppBusinessInjectorModule.LoadTypes);
        }
    }
}
