using CoreSampleApp.Business.Data.AdventureWorks2017;
using CoreSampleApp.Utilities.SimpleInjector;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreSampleApp.Business.Services
{
    public abstract class ServiceBase
    {
        private AdventureWorks2017Context _adventureWorksContext;

        protected AdventureWorks2017Context AdventureWorksContext
        {
            get
            {
                if (_adventureWorksContext == null)
                    _adventureWorksContext = SimpleInjectorAccessor.Container.GetInstance<AdventureWorks2017Context>();

                return _adventureWorksContext;
            }
        }
    }
}
