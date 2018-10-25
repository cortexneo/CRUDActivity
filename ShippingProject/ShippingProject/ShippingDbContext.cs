using Microsoft.EntityFrameworkCore;
using Shipping.EFCore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShippingProject.EFCore.Infra
{

    public class ShippingDbContext
        :DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Shipper> Shippers { get; set; }

        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Dealer> Dealers { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Laptop> Laptops { get; set; }
        public DbSet<Responsibility> Responsibilities { get; set; }
        public ShippingDbContext(
            DbContextOptions<ShippingDbContext> options)
            : base(options)
        {

        }

        public ShippingDbContext()
        {

        }

        protected override void OnConfiguring(
                    DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "Server=.;Database=Shipping;Integrated Security=true;";
            optionsBuilder.UseSqlServer(connectionString);
        }
    }

}
