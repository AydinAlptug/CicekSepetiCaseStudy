using CQRSDeneme.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CQRSDeneme.Data.Context
{
    public class MockDataPopulator
    {
        public void populateCartData()
        {
            var options = new DbContextOptionsBuilder<CartDbContext>()
                             .UseInMemoryDatabase("cart_db")
                             .Options;
            using (var context = new CartDbContext(options))
            {
                var product = new BasketProduct
                {
                    productId = 2,
                    productName = "SomeName",
                    description = "SomeDescription",
                    price = (float)100,
                    amount = 1
                };

                context.Cart.Add(product);

                product = new BasketProduct
                {
                    productId = 3,//Guid.NewGuid().ToString();
                    productName = "SomeName",
                    description = "SomeDescription",
                    price = (float)100,
                    amount = 10
                };

                context.Cart.Add(product);

                context.SaveChanges();
            }
        }
        public void populateStockProductData()
        {
            var options = new DbContextOptionsBuilder<StockDbContext>()
                             .UseInMemoryDatabase("stock_db")
                             .Options;
            using (var context = new StockDbContext(options))
            {
                var product = new StockProduct
                {
                    productId = 1, //Guid.NewGuid().ToString();
                    productName = "SomeName1",
                    description = "SomeDescription1",
                    price = (float)100,
                    stockPlace = "SomePlace1",
                    amount = 1
                };

                context.Products.Add(product);

                product = new StockProduct
                {
                    productId = 2, //Guid.NewGuid().ToString();
                    productName = "SomeName2",
                    description = "SomeDescription2",
                    price = (float)200,
                    stockPlace = "SomePlace2",
                    amount = 1
                };

                context.Products.Add(product);

                product = new StockProduct
                {
                    productId = 3, // Guid.NewGuid().ToString();
                    productName = "SomeName3",
                    description = "SomeDescription3",
                    price = (float)300,
                    stockPlace = "SomePlace3",
                    amount = 999
                };

                context.Products.Add(product);

                context.SaveChanges();
            }
        }
    }
}
