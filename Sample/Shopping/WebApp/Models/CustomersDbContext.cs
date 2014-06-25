using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Framework.OptionsModel;
using System;
using Microsoft.Framework.DependencyInjection;

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

        public static void CreateSampleData(IServiceProvider serviceProvider)
        {
            CustomersDbContext dbContext = serviceProvider.GetService<CustomersDbContext>();

            Customer cust1 = new Customer();
            cust1.Id = 1;
            cust1.Name = "Mike";

            Customer cust2 = new Customer();
            cust2.Id = 2;
            cust2.Name = "John";

            dbContext.Customers.Add(cust1);
            dbContext.Customers.Add(cust2);
            dbContext.SaveChanges();

            Order order1 = new Order();
            order1.Customer = cust1;
            order1.CustomerId = cust1.Id;
            order1.Id = 1;
            order1.OrderedDate = DateTime.UtcNow;

            Order order2 = new Order();
            order2.Customer = cust2;
            order2.CustomerId = cust2.Id;
            order2.Id = 1;
            order2.OrderedDate = DateTime.UtcNow;

            dbContext.Orders.Add(order1);
            dbContext.Orders.Add(order2);
            dbContext.SaveChanges();
        }
    }
}