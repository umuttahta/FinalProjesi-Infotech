using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChocolateApp.Data.Concrete.EfCore.Configs;
using ChocolateApp.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ChocolateApp.Data
{
    public class ChocolateAppDbContext : DbContext
    {
        // Aşağıda Connection string'i karşılıyoruz.
        public ChocolateAppDbContext(DbContextOptions options) : base(options)
        {
        }


        public DbSet<Chocolate> Chocolates { get; set; }
        public DbSet<ChocolateCategory> ChocolateCategories { get; set; }
        public DbSet<Cart> Carts { get; set; } // Sepet tablosu
        public DbSet<CartItem> CartItems { get; set; } // Sepet öğeleri tablosu
        public DbSet<Order> Orders { get; set; } // Sipariş tablosu
        public DbSet<OrderItem> OrderItems { get; set; }
         // Sipariş öğeleri tablosu
        public DbSet<Category> Categories { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ChocolateConfig).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}