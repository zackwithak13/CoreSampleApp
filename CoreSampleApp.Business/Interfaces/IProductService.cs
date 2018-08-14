using System;
using System.Collections.Generic;
using System.Text;

namespace CoreSampleApp.Business.Interfaces
{
    public interface IProductService
    {
        Core.Models.Product GetProductById(int id);
        string GetCurrentUserName();
    }
}
