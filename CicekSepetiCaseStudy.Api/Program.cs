using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CicekSepetiCaseStudy.Data.Context;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace CicekSepetiCaseStudy
{
    public class Program
    {

        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            MockDataPopulator mockDataPopulator = new MockDataPopulator();
            mockDataPopulator.populateStockProductData();
            mockDataPopulator.populateCartData();

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
