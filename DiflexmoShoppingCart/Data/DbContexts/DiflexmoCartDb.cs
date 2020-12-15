using DiflexmoShoppingCart.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeflexmoCart.Data.DbContexts
{
    public class DiflexmoCartDb : DbContext
    {
        public DiflexmoCartDb(DbContextOptions<DiflexmoCartDb> options) : base(options)
        {
            
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<ProductShoppingCart> ProductShoppingCarts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ProductShoppingCart>()
                .HasKey(ps => ps.Id );
            builder.Entity<ProductShoppingCart>()
                .HasOne(ps => ps.Product)
                .WithMany(p => p.ProductShoppingCarts)
                .HasForeignKey(ps => ps.ProductId);
            builder.Entity<ProductShoppingCart>()
                .HasOne(ps => ps.ShoppingCart)
                .WithMany(sc => sc.ProductShoppingCarts)
                .HasForeignKey(ps => ps.ShoppingCartId);
        
    }

    }
}
