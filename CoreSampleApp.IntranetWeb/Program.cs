using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace CoreSampleApp.IntranetWeb
{
    public static class Program
    {
        private static readonly string environmentName;

        static Program()
        {
#if DEBUG
            environmentName = "Development";
#elif RELEASE
            environmentName = "Production";
#endif
        }

        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseEnvironment(environmentName)
                .UseStartup<Startup>()
                .Build();
    }
}
