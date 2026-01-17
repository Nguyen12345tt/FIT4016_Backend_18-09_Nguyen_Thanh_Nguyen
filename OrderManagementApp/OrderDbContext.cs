using Microsoft.EntityFrameworkCore;
using System;

namespace OrderManagementApp
{
    public class OrderDbContext : DbContext
    {
        public OrderDbContext(DbContextOptions<OrderDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasIndex(p => p.Name).IsUnique();
            modelBuilder.Entity<Product>().HasIndex(p => p.Sku).IsUnique();
            modelBuilder.Entity<Order>().HasIndex(o => o.OrderNumber).IsUnique();
            modelBuilder.Entity<Order>().HasIndex(o => o.CustomerEmail).IsUnique();
            modelBuilder.Entity<Product>().Property(p => p.Price).HasColumnType("decimal(18,2)");

            for (int i = 1; i <= 15; i++)
            {
                modelBuilder.Entity<Product>().HasData(new Product
                {
                    Id = i,
                    Name = $"Product {i}",
                    Sku = $"SKU-{i:000}",
                    Price = 100 * i,
                    StockQuantity = 100,
                    Category = "General",
                    CreatedAt = DateTime.Now
                });
            }
        }
    }
}