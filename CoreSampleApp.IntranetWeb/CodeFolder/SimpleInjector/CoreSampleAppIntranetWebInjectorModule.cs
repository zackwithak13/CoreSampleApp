using Microsoft.Extensions.Configuration;
using CoreSampleApp.Business.SimpleInjector;
using CoreSampleApp.Utilities.SimpleInjector;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Security.Principal;
using Microsoft.AspNetCore.Http;

namespace CoreSampleApp.SimpleInjector
{
    public static class CoreSampleAppIntranetWebInjectorModule
    {
        public static void LoadTypes(Container container)
        {
            container.Register<IIdentity>(() => SimpleInjectorAccessor.Container.GetInstance<IHttpContextAccessor>().HttpContext.User.Identity, Lifestyle.Transient);
            SimpleInjectorAccessor.Load(CoreSampleAppBusinessInjectorModule.LoadTypes);
        }
    }
}
