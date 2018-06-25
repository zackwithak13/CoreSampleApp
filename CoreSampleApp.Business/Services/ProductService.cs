using CoreSampleApp.Business.Factories;
using CoreSampleApp.Business.Interfaces;
using EFCore.BulkExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreSampleApp.Business.Services
{
    public class ProductService : ServiceBase, IProductService
    {
        public Core.Models.Product GetProductById(int id)
        {
            var result = AdventureWorksContext.Find<Data.Product>(id);

            return Factory.CreateProductDTO(result);
        }

        public void InsertProducts(List<Core.Models.Product> products)
        {
            var productEntities = products.Select(Factory.CreateProductEntity).ToList();

            AdventureWorksContext.BulkInsert(productEntities);
        }
    }
}
