using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata;
using System;

namespace WebApp.Models
{
    public class CustomersDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        public DbSet<Order> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptions builder)
        {
            SetupDataStore(builder);
        }

        // For unit tests to override this
        protected virtual void SetupDataStore(DbContextOptions builder)
        {
            builder.UseInMemoryStore();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Customer>().Key(customer => customer.Id);
            builder.Entity<Order>().Key(order => order.Id);
        }
    }
}