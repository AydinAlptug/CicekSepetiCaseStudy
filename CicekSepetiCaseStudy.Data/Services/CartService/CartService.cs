using CicekSepetiCaseStudy.Core.Models;
using CicekSepetiCaseStudy.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CicekSepetiCaseStudy.Services
{
    public class CartService : ICartService
    {

        public readonly CartDbContext context;

        public CartService(CartDbContext context)
        {
            this.context = context;
        }

        public async Task<BasketProduct> AddProductToCartAsync(BasketProduct product)
        {
            
            if (context.Cart.Contains(product))
            {
                return default;
            }
            context.Cart.Add(product);
            await context.SaveChangesAsync();
            return product;
        }

        public async Task<IEnumerable<BasketProduct>> GetAllProducts()
        {
            return await context.Cart.ToListAsync();
        }

        public async Task<BasketProduct> GetProductById(int id)
        {
            return await context.Cart.FirstOrDefaultAsync(p => p.productId.Equals(id));// == id);
        }

        public async Task<int> RemoveProductFromCart(BasketProduct product)
        {
            context.Cart.Remove(product);
            return await context.SaveChangesAsync();
        }

        public async Task<int> UpdateProductInCart(BasketProduct product)
        {
            context.Cart.Update(product);
            return await context.SaveChangesAsync();
        }
    }
}
