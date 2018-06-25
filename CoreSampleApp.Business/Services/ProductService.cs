using CoreSampleApp.Business.Factories;
using CoreSampleApp.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreSampleApp.Business.Services
{
    public class ProductService : ServiceBase, IProductService
    {
        public Core.Models.Product GetProductById(int id)
        {
            var result = AdventureWorksContext.Product.Find(id);

            return Factory.CreateProductDTO(result);
        }
    }
}
