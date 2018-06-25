using System;
using System.Collections.Generic;
using System.Text;

namespace CoreSampleApp.Business.Factories
{
    public static partial class Factory
    {
        public static Core.Models.Product CreateProductDTO(Data.Product input)
        {
            return input == null ? null : new Core.Models.Product()
            {
                ProductID = input.ProductId,
                Name = input.Name,
                ProductNumber = input.ProductNumber,
                MakeFlag = input.MakeFlag,
                FinishedGoodsFlag = input.FinishedGoodsFlag,
                Color = input.Color,
                SafetyStockLevel = input.SafetyStockLevel,
                ReorderPoint = input.ReorderPoint,
                StandardCost = input.StandardCost,
                ListPrice = input.ListPrice,
                Size = input.Size,
                SizeUnitMeasureCode = input.SizeUnitMeasureCode,
                WeightUnitMeasureCode = input.WeightUnitMeasureCode,
                Weight = input.Weight,
                DaysToManufacture = input.DaysToManufacture,
                ProductLine = input.ProductLine,
                Class = input.Class,
                Style = input.Style,
                ProductSubcategoryID = input.ProductSubcategoryId,
                ProductModelID = input.ProductModelId,
                SellStartDate = input.SellStartDate,
                SellEndDate = input.SellEndDate,
                DiscontinuedDate = input.DiscontinuedDate,
                rowguid = input.Rowguid,
                ModifiedDate = input.ModifiedDate,
            };
        }

        public static Data.Product CreateProductEntity(Core.Models.Product input)
        {
            return input == null ? null : new Data.Product()
            {
                ProductId = input.ProductID,
                Name = input.Name,
                ProductNumber = input.ProductNumber,
                MakeFlag = input.MakeFlag,
                FinishedGoodsFlag = input.FinishedGoodsFlag,
                Color = input.Color,
                SafetyStockLevel = input.SafetyStockLevel,
                ReorderPoint = input.ReorderPoint,
                StandardCost = input.StandardCost,
                ListPrice = input.ListPrice,
                Size = input.Size,
                SizeUnitMeasureCode = input.SizeUnitMeasureCode,
                WeightUnitMeasureCode = input.WeightUnitMeasureCode,
                Weight = input.Weight,
                DaysToManufacture = input.DaysToManufacture,
                ProductLine = input.ProductLine,
                Class = input.Class,
                Style = input.Style,
                ProductSubcategoryId = input.ProductSubcategoryID,
                ProductModelId = input.ProductModelID,
                SellStartDate = input.SellStartDate,
                SellEndDate = input.SellEndDate,
                DiscontinuedDate = input.DiscontinuedDate,
                Rowguid = input.rowguid,
                ModifiedDate = input.ModifiedDate,
            };
        }
    }
}
