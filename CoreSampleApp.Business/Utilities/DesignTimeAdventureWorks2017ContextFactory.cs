using CoreSampleApp.Business.Data.AdventureWorks2017;
using CoreSampleApp.Utilities.SimpleInjector;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using SimpleInjector;
using SimpleInjector.Lifestyles;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CoreSampleApp.Business.Utilities
{
    public class DesignTimeAdventureWorks2017ContextFactory : IDesignTimeDbContextFactory<AdventureWorks2017Context>
    {
        public AdventureWorks2017Context CreateDbContext(string[] args)
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            SimpleInjectorAccessor.RegisterContainer(container);

            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();


            container.Register<IConfiguration>(() => configuration);

            return new AdventureWorks2017Context();
        }
    }
}
