//using Csv;
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
using CoreSampleApp.Utilities.StringResources;
using System.Resources;
using CsvHelper;

namespace CoreSampleApp
{
    static class Program
    {
        class FileData
        {
            public int FileId { get; set; }
            public int RowNum { get; set; }
            public int ColNum { get; set; }
            public string Value { get; set; }
        }

        static Program()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            SimpleInjectorAccessor.RegisterContainer(container);
            SimpleInjectorAccessor.Load(CoreSampleAppInjectorModule.LoadTypes);
        }

        static void Main(string[] args)
        {

            var fileLogger = new FileLogger("FilePath");
            SimpleInjectorAccessor.Container.RegisterInstance<ILogger>(fileLogger);

            var options = new CsvHelper.Configuration.Configuration()
            {
                HasHeaderRecord = false,
                TrimOptions = CsvHelper.Configuration.TrimOptions.Trim,                
            };
            List<FileData> fileDatas = new List<FileData>();
            using (var reader = new StreamReader("sample.csv"))
            {
                using (var csv = new CsvReader(reader, options))
                {
                    var lines = csv.GetRecords<dynamic>();                    
                    foreach (var line in lines)
                    {
                        //do stuff
                    }                    
                }
            }
            //var options = new CsvOptions()
            //{
            //    HeaderMode = HeaderMode.HeaderAbsent,
            //    ValidateColumnCount = false,
            //    TrimData = true,
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

            using (AsyncScopedLifestyle.BeginScope(SimpleInjectorAccessor.Container))
            {
                fileLogger.LogFilePath = "NewFilePath";

                Logger.Log(Core.ENUMS.LOGGINGMESSAGETYPES.Trace, LoggingMessages.ResourceManager.GetString("String1"));
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
}
