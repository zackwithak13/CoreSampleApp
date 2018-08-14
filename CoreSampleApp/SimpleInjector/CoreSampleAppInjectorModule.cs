using Microsoft.Extensions.Configuration;
using CoreSampleApp.Business.SimpleInjector;
using CoreSampleApp.Utilities.SimpleInjector;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Security.Principal;
using System.Threading;

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

            var identity = new GenericIdentity("Processor");
            container.Register<IIdentity>(() => identity);

            SimpleInjectorAccessor.Load(CoreSampleAppBusinessInjectorModule.LoadTypes);
        }
    }
}
