using System;
using System.Collections.Generic;

namespace CoreSampleApp.Business.Data.AdventureWorks2017
{
    public partial class CountryRegionCurrency
    {
        public string CountryRegionCode { get; set; }
        public string CurrencyCode { get; set; }
        public DateTime ModifiedDate { get; set; }

        public CountryRegion CountryRegionCodeNavigation { get; set; }
        public Currency CurrencyCodeNavigation { get; set; }
    }
}
