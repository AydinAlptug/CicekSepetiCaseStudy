using CQRSDeneme.Core.Models;
using CQRSDeneme.Data.Context;
using CQRSDeneme.Data.Services.StrockService;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CQRSDeneme.Data.Services.StockService
{
    public class StockService : IStockService
    {
        public readonly StockDbContext context;

        public StockService(StockDbContext context)
        {
            this.context = context;
        }

        public async Task<int> CheckStockAmount(int productId)
        {
            var product = await context.Products.FirstOrDefaultAsync(p => p.productId.Equals(productId));// == id);

            if (product == null) return -1;

            return product.amount;
        }
        public async Task<StockProduct> GetStockProduct(int productId)
        {
            var product = await context.Products.FirstOrDefaultAsync(p => p.productId.Equals(productId));// == id);

            if (product == null) return null;

            return product;
        }

    }
}
