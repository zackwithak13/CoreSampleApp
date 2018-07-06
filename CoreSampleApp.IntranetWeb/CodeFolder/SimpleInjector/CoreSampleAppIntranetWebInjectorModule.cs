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
    public static class CoreSampleAppIntranetWebInjectorModule
    {
        public static void LoadTypes(Container container)
        {
            SimpleInjectorAccessor.Load(CoreSampleAppBusinessInjectorModule.LoadTypes);
        }
    }
}
