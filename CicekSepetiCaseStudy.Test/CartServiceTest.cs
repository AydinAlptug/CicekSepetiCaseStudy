using CicekSepetiCaseStudy.Core.Models;
using CicekSepetiCaseStudy.Data.Context;
using CicekSepetiCaseStudy.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CicekSepetiCaseStudy.Test
{
    [TestClass]
    public class CartServiceTest
    {
        [TestMethod]
        public void GetProductByIdTest()
        {
            int test_id = 912;
            BasketProduct test_product;

            var options = new DbContextOptionsBuilder<CartDbContext>()
                             .UseInMemoryDatabase("test_cart_db_1")
                             .Options;
            using (var context = new CartDbContext(options))
            {
                test_product = new BasketProduct
                {
                    productId = test_id,
                    productName = "SomeName",
                    description = "SomeDescription",
                    price = (float)100,
                    amount = 1
                };

                context.Cart.Add(test_product);
                context.SaveChanges();
            }
            using (var context = new CartDbContext(options))
            {
                CartService cartService = new CartService(context);
                Assert.AreEqual(cartService.GetProductById(test_product.productId).Result.productId, test_product.productId);
                Assert.AreNotEqual(cartService.GetProductById(test_product.productId).Result.productId, -1);
            }
        }
        [TestMethod]
        public void GetAllProductsTest()
        {
            int test_id = 912;
            BasketProduct test_product;

            var options = new DbContextOptionsBuilder<CartDbContext>()
                             .UseInMemoryDatabase("test_cart_db_2")
                             .Options;
            using (var context = new CartDbContext(options))
            {
                test_product = new BasketProduct
                {
                    productId = test_id,
                    productName = "SomeName",
                    description = "SomeDescription",
                    price = (float)100,
                    amount = 1
                };

                context.Cart.Add(test_product);
                context.SaveChanges();
            }
            using (var context = new CartDbContext(options))
            {
                CartService cartService = new CartService(context);
                Assert.AreEqual(cartService.GetAllProducts().Result.Count(), context.Cart.Count());
                Assert.AreNotEqual(cartService.GetAllProducts().Result.Count(), -1);
            }
        }

        [TestMethod]
        public void AddProductToCartAsyncTest()
        {
            int test_id = 913;
            BasketProduct test_product;

            var options = new DbContextOptionsBuilder<CartDbContext>()
                             .UseInMemoryDatabase("test_cart_db_3")
                             .Options;
            using (var context = new CartDbContext(options))
            {
                test_product = new BasketProduct
                {
                    productId = test_id,
                    basketProductGuid = Guid.NewGuid(),
                    productName = "SomeName",
                    description = "SomeDescription",
                    price = (float)100,
                    amount = 1
                };

                //context.Cart.Add(test_product);
                //context.SaveChanges();
            }
            using (var context = new CartDbContext(options))
            {
                CartService cartService = new CartService(context);
                Assert.AreEqual(cartService.AddProductToCartAsync(test_product).Result, test_product);
                Assert.AreEqual(cartService.AddProductToCartAsync(test_product).Result, null);
            }
        }
    }
}
