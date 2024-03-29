﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication.Data;
using data = WebApplication.Data.Entitis;

namespace WebApplication.Data.Migrations
{
    [DbContext(typeof(data.Project1Context))]
    [Migration("20191022141848_WebApplication")]
    partial class WebApplication
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebApplication.Data.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("WebApplication.Data.Inventory", b =>
                {
                    b.Property<int>("ProductId")
                        .HasColumnName("ProductID")
                        .HasColumnType("int");

                    b.Property<int>("LocationId")
                        .HasColumnName("LocationID")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("ProductId", "LocationId")
                        .HasName("PK__Inventor__DA732CAA35F81D75");

                    b.HasIndex("LocationId");

                    b.ToTable("Inventory");
                });

            modelBuilder.Entity("WebApplication.Data.Location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("Location");
                });

            modelBuilder.Entity("WebApplication.Data.OrderDetails", b =>
                {
                    b.Property<int>("OrderId")
                        .HasColumnName("OrderID")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnName("ProductID")
                        .HasColumnType("int");

                    b.Property<int?>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("OrderId", "ProductId")
                        .HasName("PK__OrderDet__08D097C1150A2C2E");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("WebApplication.Data.Orders", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CustomerId")
                        .HasColumnName("CustomerID")
                        .HasColumnType("int");

                    b.Property<int?>("LocationId")
                        .HasColumnName("LocationID")
                        .HasColumnType("int");

                    b.Property<DateTime?>("OrderTime")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("LocationId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("WebApplication.Data.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<decimal>("Price")
                        .HasColumnType("money");

                    b.HasKey("Id");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("WebApplication.Data.Inventory", b =>
                {
                    b.HasOne("WebApplication.Data.Location", "Location")
                        .WithMany("Inventory")
                        .HasForeignKey("LocationId")
                        .HasConstraintName("FK__Inventory__Locat__1332DBDC")
                        .IsRequired();

                    b.HasOne("WebApplication.Data.Product", "Product")
                        .WithMany("Inventory")
                        .HasForeignKey("ProductId")
                        .HasConstraintName("FK__Inventory__Produ__123EB7A3")
                        .IsRequired();
                });

            modelBuilder.Entity("WebApplication.Data.OrderDetails", b =>
                {
                    b.HasOne("WebApplication.Data.Orders", "Order")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderId")
                        .HasConstraintName("FK__OrderDeta__Order__19DFD96B")
                        .IsRequired();

                    b.HasOne("WebApplication.Data.Product", "Product")
                        .WithMany("OrderDetails")
                        .HasForeignKey("ProductId")
                        .HasConstraintName("FK__OrderDeta__Produ__1AD3FDA4")
                        .IsRequired();
                });

            modelBuilder.Entity("WebApplication.Data.Orders", b =>
                {
                    b.HasOne("WebApplication.Data.Customer", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerId")
                        .HasConstraintName("FK_Orders_Customer_ID");

                    b.HasOne("WebApplication.Data.Location", "Location")
                        .WithMany("Orders")
                        .HasForeignKey("LocationId")
                        .HasConstraintName("FK_Orders_Location_ID");
                });
#pragma warning restore 612, 618
        }
    }
}
