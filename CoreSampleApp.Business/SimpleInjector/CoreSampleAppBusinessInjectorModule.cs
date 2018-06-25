using CoreSampleApp.Business.Data;
using CoreSampleApp.Business.Interfaces;
using CoreSampleApp.Business.Services;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreSampleApp.Business.SimpleInjector
{
    public static class CoreSampleAppBusinessInjectorModule
    {
        public static void LoadTypes(Container container)
        {
            container.Register<AdventureWorks2017Context>(() => new AdventureWorks2017Context());

            container.Register<IProductService, ProductService>();
        }
    }
}
