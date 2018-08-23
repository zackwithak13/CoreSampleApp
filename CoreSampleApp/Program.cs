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
                TrimOptions = CsvHelper.Configuration.TrimOptions.Trim | CsvHelper.Configuration.TrimOptions.InsideQuotes,
                BadDataFound = null,
            };
            options.TypeConverterOptionsCache.GetOptions<string>().NullValues.Add(string.Empty);
            using (var reader = new StreamReader("C:\\csvTest.txt"))
            {
                using (var csvParser = new CsvParser(reader, options))
                {
                    string[] line;
                    var row = 0;
                    while ((line = csvParser.Read()) != null)
                    {
                        for (int col = 0; col < line.Length; col++)
                        {
                            if (line[col] == string.Empty) { line[col] = null; }
                            if (row == 12 && col == 1)
                            { string dfa = string.Empty; }
                            var test = line[col];
                        }
                        row++;
                    }
                }
            }

            using (AsyncScopedLifestyle.BeginScope(SimpleInjectorAccessor.Container))
            {
                fileLogger.LogFilePath = "NewFilePath";

                Logger.Log(Core.ENUMS.LOGGINGMESSAGETYPES.Trace, LoggingMessages.ResourceManager.GetString("String1"));
                var productService = SimpleInjectorAccessor.Container.GetInstance<IProductService>();
                var test = productService.GetCurrentUserName();
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
