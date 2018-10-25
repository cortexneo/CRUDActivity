﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ShippingProject.EFCore.Infra;

namespace ShippingProject.EFCore.Infra.Migrations
{
    [DbContext(typeof(ShippingDbContext))]
    [Migration("20181024053317_responsibiity")]
    partial class responsibiity
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Shipping.EFCore.Domain.Models.Car", b =>
                {
                    b.Property<Guid>("CarID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CarColor");

                    b.Property<string>("CarFuel");

                    b.Property<string>("CarManufacturer");

                    b.Property<string>("CarName");

                    b.Property<string>("CarType");

                    b.Property<string>("Transmission");

                    b.Property<string>("YearModel");

                    b.Property<bool?>("inStock");

                    b.HasKey("CarID");

                    b.ToTable("Car");
                });

            modelBuilder.Entity("Shipping.EFCore.Domain.Models.Category", b =>
                {
                    b.Property<Guid>("CategoryID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CategoryName")
                        .HasMaxLength(100);

                    b.Property<string>("Description")
                        .HasMaxLength(100);

                    b.Property<byte[]>("Picture");

                    b.HasKey("CategoryID");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("Shipping.EFCore.Domain.Models.Customer", b =>
                {
                    b.Property<Guid>("CustomerID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address")
                        .HasMaxLength(100);

                    b.Property<string>("City")
                        .HasMaxLength(100);

                    b.Property<string>("ContactName")
                        .HasMaxLength(60);

                    b.Property<string>("ContactTitle")
                        .HasMaxLength(60);

                    b.Property<string>("Country")
                        .HasMaxLength(100);

                    b.Property<string>("CustomerName")
                        .HasMaxLength(60);

                    b.Property<string>("Fax")
                        .HasMaxLength(15);

                    b.Property<string>("Phone")
                        .HasMaxLength(15);

                    b.Property<string>("PostalCode")
                        .HasMaxLength(15);

                    b.Property<string>("Region")
                        .HasMaxLength(100);

                    b.HasKey("CustomerID");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("Shipping.EFCore.Domain.Models.Dealer", b =>
                {
                    b.Property<Guid>("DealerID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<string>("City");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("Phone");

                    b.Property<string>("Photo");

                    b.Property<string>("PostalCode");

                    b.Property<string>("Region");

                    b.Property<bool?>("isActive");

                    b.HasKey("DealerID");

                    b.ToTable("Dealer");
                });

            modelBuilder.Entity("Shipping.EFCore.Domain.Models.Employee", b =>
                {
                    b.Property<Guid>("EmployeeID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address")
                        .HasMaxLength(100);

                    b.Property<DateTime>("BirthDate");

                    b.Property<string>("City")
                        .HasMaxLength(100);

                    b.Property<string>("Country")
                        .HasMaxLength(100);

                    b.Property<string>("Extension")
                        .HasMaxLength(15);

                    b.Property<string>("FirstName")
                        .HasMaxLength(60);

                    b.Property<DateTime?>("HireDate");

                    b.Property<string>("HomePhone")
                        .HasMaxLength(15);

                    b.Property<string>("LastName")
                        .HasMaxLength(60);

                    b.Property<string>("Notes")
                        .HasMaxLength(1000);

                    b.Property<byte[]>("Photo");

                    b.Property<string>("PostalCode")
                        .HasMaxLength(15);

                    b.Property<string>("Region")
                        .HasMaxLength(100);

                    b.Property<Guid>("ReportsTo");

                    b.Property<string>("Title")
                        .HasMaxLength(60);

                    b.Property<string>("TitleOfCourtesy")
                        .HasMaxLength(60);

                    b.HasKey("EmployeeID");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("Shipping.EFCore.Domain.Models.Laptop", b =>
                {
                    b.Property<Guid>("LaptopID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("LaptopName")
                        .IsRequired();

                    b.Property<int>("Quantity");

                    b.HasKey("LaptopID");

                    b.ToTable("Laptop");
                });

            modelBuilder.Entity("Shipping.EFCore.Domain.Models.Order", b =>
                {
                    b.Property<Guid>("OrderID")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("CustomerID");

                    b.Property<Guid>("EmployeeID");

                    b.Property<decimal>("Freight");

                    b.Property<DateTime>("OrderDate");

                    b.Property<DateTime>("RequiredDate");

                    b.Property<string>("ShipAddress")
                        .HasMaxLength(100);

                    b.Property<string>("ShipCity")
                        .HasMaxLength(100);

                    b.Property<string>("ShipCountry")
                        .HasMaxLength(100);

                    b.Property<string>("ShipName")
                        .HasMaxLength(100);

                    b.Property<string>("ShipPostalCode")
                        .HasMaxLength(15);

                    b.Property<string>("ShipRegion")
                        .HasMaxLength(100);

                    b.Property<DateTime>("ShippedDate");

                    b.Property<Guid>("ShipperID");

                    b.HasKey("OrderID");

                    b.HasIndex("CustomerID");

                    b.HasIndex("EmployeeID");

                    b.HasIndex("ShipperID");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("Shipping.EFCore.Domain.Models.OrderDetail", b =>
                {
                    b.Property<Guid>("OrderDetailID")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("Discount");

                    b.Property<Guid>("OrderID");

                    b.Property<int>("OrderLineID");

                    b.Property<Guid>("ProductID");

                    b.Property<decimal>("Quantity");

                    b.Property<decimal>("UnitPrice");

                    b.HasKey("OrderDetailID");

                    b.HasIndex("OrderID");

                    b.HasIndex("ProductID");

                    b.ToTable("OrderDetail");
                });

            modelBuilder.Entity("Shipping.EFCore.Domain.Models.Person", b =>
                {
                    b.Property<Guid>("PersonID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Barangay");

                    b.Property<DateTime>("Birthday");

                    b.Property<string>("City")
                        .IsRequired();

                    b.Property<string>("Country")
                        .IsRequired();

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<string>("Gender")
                        .IsRequired();

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.Property<int>("Latitude");

                    b.Property<int>("Longtitude");

                    b.Property<string>("MiddleName");

                    b.Property<string>("Nationality")
                        .IsRequired();

                    b.Property<string>("PhoneNumber")
                        .IsRequired();

                    b.Property<byte[]>("Photo");

                    b.Property<int>("PostalCode");

                    b.Property<string>("Region")
                        .IsRequired();

                    b.Property<string>("RelationshipStatus")
                        .IsRequired();

                    b.Property<string>("Religion");

                    b.Property<string>("Street")
                        .IsRequired();

                    b.HasKey("PersonID");

                    b.ToTable("Person");
                });

            modelBuilder.Entity("Shipping.EFCore.Domain.Models.Product", b =>
                {
                    b.Property<Guid>("ProductID")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("CategoryID");

                    b.Property<bool>("Discontinued");

                    b.Property<string>("ProductName")
                        .HasMaxLength(100);

                    b.Property<decimal>("ReorderLevel");

                    b.Property<Guid>("SupplierID");

                    b.Property<decimal>("UnitPrice");

                    b.Property<decimal>("UnitsInStock");

                    b.Property<decimal>("UnitsOnOrder");

                    b.HasKey("ProductID");

                    b.HasIndex("CategoryID");

                    b.HasIndex("SupplierID");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("Shipping.EFCore.Domain.Models.Responsibility", b =>
                {
                    b.Property<Guid>("ResponsibilityID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateCreated");

                    b.Property<string>("Description");

                    b.Property<decimal>("Price");

                    b.Property<bool>("isActive");

                    b.HasKey("ResponsibilityID");

                    b.ToTable("Responsibility");
                });

            modelBuilder.Entity("Shipping.EFCore.Domain.Models.Shipper", b =>
                {
                    b.Property<Guid>("ShipperID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CompanyName")
                        .HasMaxLength(100);

                    b.Property<string>("Phone")
                        .HasMaxLength(15);

                    b.HasKey("ShipperID");

                    b.ToTable("Shipper");
                });

            modelBuilder.Entity("Shipping.EFCore.Domain.Models.Supplier", b =>
                {
                    b.Property<Guid>("SupplierID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address")
                        .HasMaxLength(100);

                    b.Property<string>("City")
                        .HasMaxLength(100);

                    b.Property<string>("CompanyName")
                        .HasMaxLength(60);

                    b.Property<string>("ContactName")
                        .HasMaxLength(60);

                    b.Property<string>("ContactTitle")
                        .HasMaxLength(60);

                    b.Property<string>("Country")
                        .HasMaxLength(100);

                    b.Property<string>("Fax")
                        .HasMaxLength(15);

                    b.Property<string>("HomePage")
                        .HasMaxLength(100);

                    b.Property<string>("Phone")
                        .HasMaxLength(15);

                    b.Property<string>("PostalCode")
                        .HasMaxLength(15);

                    b.Property<string>("Region")
                        .HasMaxLength(100);

                    b.HasKey("SupplierID");

                    b.ToTable("Supplier");
                });

            modelBuilder.Entity("Shipping.EFCore.Domain.Models.Order", b =>
                {
                    b.HasOne("Shipping.EFCore.Domain.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Shipping.EFCore.Domain.Models.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Shipping.EFCore.Domain.Models.Shipper", "ShipVia")
                        .WithMany()
                        .HasForeignKey("ShipperID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Shipping.EFCore.Domain.Models.OrderDetail", b =>
                {
                    b.HasOne("Shipping.EFCore.Domain.Models.Order", "Order")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Shipping.EFCore.Domain.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Shipping.EFCore.Domain.Models.Product", b =>
                {
                    b.HasOne("Shipping.EFCore.Domain.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Shipping.EFCore.Domain.Models.Supplier", "Supplier")
                        .WithMany()
                        .HasForeignKey("SupplierID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
