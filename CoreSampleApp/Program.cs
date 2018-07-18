using Csv;
using CoreSampleApp.Business.Interfaces;
using CoreSampleApp.SimpleInjector;
using CoreSampleApp.Utilities.SimpleInjector;
using SimpleInjector;
using SimpleInjector.Lifestyles;
using System;
using System.Collections.Generic;
using System.IO;
using CoreSampleApp.Business.Utilities;
using CoreSampleApp.Business.Utilities.Logging;

namespace CoreSampleApp
{
    class Program
    {
        class FileData
        {
            public int FileId { get; set; }
            public int RowNum { get; set; }
            public int ColNum { get; set; }
            public string Value { get; set; }
        }
        static void Main(string[] args)
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            SimpleInjectorAccessor.RegisterContainer(container);
            SimpleInjectorAccessor.Load(CoreSampleAppInjectorModule.LoadTypes);

            //List<FileData> fileDatas = new List<FileData>();
            //var csv = File.ReadAllText("sample.csv");
            //var options = new CsvOptions()
            //{
            //    HeaderMode = HeaderMode.HeaderAbsent,
            //    ValidateColumnCount = false,
            //};
            //int row = 1;

            //foreach (var line in CsvReader.ReadFromText(csv, options))
            //{
            //    // Code to build an entry or perform other actions goes here
            //    for (int col = 0; col < line.ColumnCount; col++)
            //    {
            //        fileDatas.Add(new FileData()
            //        {
            //            FileId = 0,
            //            RowNum = row,
            //            ColNum = col,
            //            Value = line[col]
            //        });
            //    }
            //    row++;
            //}
            //Bulk insert data from the list

            SimpleInjectorAccessor.Container.Register<ILogger>(() => new ProcessorLogger("FilePath"));

            Logger.Log(Core.ENUMS.LOGGINGMESSAGETYPES.Trace, "This is a logging message");
            var productService = SimpleInjectorAccessor.Container.GetInstance<IProductService>();
            int id;
            string entry;
            do
            {
                Console.Write("Enter Product Id:  ");
                entry = Console.ReadLine();
                if (int.TryParse(entry, out id))
                {
                    var product = productService.GetProductById(id);

                    if (product != null)
                    {
                        Console.WriteLine($"Name: {product.Name}\nPrice: {product.ListPrice}");
                    }
                    else
                    {
                        Console.WriteLine("Product Not Found");
                    }
                }
                else
                {
                    Console.WriteLine("Failed");
                }
            } while (entry != "quit");
        }
    }
}
