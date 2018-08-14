using CoreSampleApp.Business.Data.AdventureWorks2017;
using CoreSampleApp.Business.Interfaces;
using CoreSampleApp.Business.Services;
using CoreSampleApp.Business.Utilities;
using Microsoft.EntityFrameworkCore.SqlServer.Storage.Internal;
using SimpleInjector;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreSampleApp.Business.SimpleInjector
{
    public static class CoreSampleAppBusinessInjectorModule
    {
        public static void LoadTypes(Container container)
        {
            container.Register<AdventureWorks2017Context>(() => new AdventureWorks2017Context(), Lifestyle.Scoped);

            container.Register<IProductService, ProductService>();
        }
    }
}
