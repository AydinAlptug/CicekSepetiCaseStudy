using CQRSDeneme.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CQRSDeneme.Data.Context
{
    public class CartDbContext : DbContext
    {
        public CartDbContext(DbContextOptions<CartDbContext> options) : base(options)
        {
        }

        public DbSet<BasketProduct> Cart { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
