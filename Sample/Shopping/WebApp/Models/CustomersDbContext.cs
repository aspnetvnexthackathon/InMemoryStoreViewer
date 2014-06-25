using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Framework.OptionsModel;
using System;

namespace WebApp.Models
{
    public class CustomersDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        public DbSet<Order> Orders { get; set; }

        public CustomersDbContext(IServiceProvider serviceProvider, IOptionsAccessor<DbContextOptions> optionsAccessor)
            : base(serviceProvider, optionsAccessor.Options)
        {
            // Create the database and schema if it doesn't exist
            // This is a temporary workaround to create database until Entity Framework database migrations 
            // are supported in ASP.NET vNext
            
        }
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