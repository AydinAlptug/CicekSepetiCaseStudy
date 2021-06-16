using CQRSDeneme.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CQRSDeneme.Data.Context
{
    public class StockDbContext : DbContext
    {
        public StockDbContext(DbContextOptions<StockDbContext> options) : base(options)
        {
        }

        public DbSet<StockProduct> Products { get; set; }
    }
}
