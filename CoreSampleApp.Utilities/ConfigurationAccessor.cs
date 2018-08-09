using CoreSampleApp.Utilities.SimpleInjector;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreSampleApp.Utilities
{
    public static class ConfigurationAccessor
    {
        public static readonly string CompanyCode;

        static ConfigurationAccessor()
        {
            var _config = SimpleInjectorAccessor.Container.GetInstance<IConfiguration>();
            CompanyCode = _config.GetValue<string>("companyCode");
        }
    }
}
