using CicekSepetiCaseStudy.Core.Models;
using CicekSepetiCaseStudy.Data.Context;
using CicekSepetiCaseStudy.Data.Services.StockService;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace CicekSepetiCaseStudy.Test
{
    [TestClass]
    public class StockServiceTest
    {

        [TestMethod]
        public void CheckStockAmountTest()
        {
            int test_amount = 1;
            StockProduct test_product;

            var options = new DbContextOptionsBuilder<StockDbContext>()
                             .UseInMemoryDatabase("test_stock_db")
                             .Options;
            using (var context = new StockDbContext(options))
            {
                test_product = new StockProduct
                {
                    productId = 999,
                    productName = "TestSomeName",
                    description = "TestSomeDescription",
                    price = (float)100,
                    stockPlace = "TestSomePlace",
                    amount = test_amount
                };

                context.Products.Add(test_product);
                context.SaveChanges();
            }
            using (var context = new StockDbContext(options))
            {
                StockService stockService = new StockService(context);
                Assert.AreEqual(stockService.CheckStockAmount(test_product.productId).Result, test_amount);
                Assert.AreNotEqual(stockService.CheckStockAmount(test_product.productId).Result, -1);
            }
        }


        [TestMethod]
        public void GetStockProductTest()
        {
            int test_amount = 1;
            StockProduct test_product, test_product2;

            var options = new DbContextOptionsBuilder<StockDbContext>()
                             .UseInMemoryDatabase("test_stock_db")
                             .Options;
            using (var context = new StockDbContext(options))
            {
                test_product = new StockProduct
                {
                    productId = 999,
                    productName = "TestSomeName1",
                    description = "TestSomeDescription1",
                    price = (float)100,
                    stockPlace = "TestSomePlace1",
                    amount = test_amount
                };

                test_product2 = new StockProduct
                {
                    productId = 998,
                    productName = "TestSomeName2",
                    description = "TestSomeDescription2",
                    price = (float)100,
                    stockPlace = "TestSomePlace2",
                    amount = test_amount
                };

                context.Products.Add(test_product);
                context.Products.Add(test_product2);
                context.SaveChanges();
            }
            using (var context = new StockDbContext(options))
            {
                StockService stockService = new StockService(context);
                Assert.AreEqual(stockService.GetStockProduct(test_product.productId).Result.productId, test_product.productId);
                Assert.AreNotEqual(stockService.GetStockProduct(test_product.productId).Result.productId, test_product2.productId);
            }
        }

    }
}
