﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using POSSystem.Persistance;

#nullable disable

namespace POSSystem.Persistance.Migrations
{
    [DbContext(typeof(POSSystemDBContext))]
    [Migration("20250108091818_dbinit")]
    partial class dbinit
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("POSSystem.Domain.Entities.AdminEntity", b =>
                {
                    b.Property<int>("AdminId")
                        .HasColumnType("int");

                    b.Property<string>("AdminName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("AdminId");

                    b.ToTable("Admins");
                });

            modelBuilder.Entity("POSSystem.Domain.Entities.CashierEntity", b =>
                {
                    b.Property<int>("CashierId")
                        .HasColumnType("int");

                    b.Property<string>("CashierName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("CashierId");

                    b.ToTable("Cashiers");
                });

            modelBuilder.Entity("POSSystem.Domain.Entities.CustomerEntity", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerId"));

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("CustomerId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("POSSystem.Domain.Entities.OrderProductEntity", b =>
                {
                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("OrderId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderProducts");
                });

            modelBuilder.Entity("POSSystem.Domain.Entities.common.InventoryEntity", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"));

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("ProductStock")
                        .HasColumnType("int");

                    b.HasKey("ProductId");

                    b.ToTable("Inventories");
                });

            modelBuilder.Entity("POSSystem.Domain.Entities.common.OrderEntity", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderId"));

                    b.Property<int?>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("OrderStatus")
                        .HasColumnType("int");

                    b.Property<int>("OrderTotal")
                        .HasColumnType("int");

                    b.HasKey("OrderId");

                    b.HasIndex("CustomerId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("POSSystem.Domain.Entities.common.PermissionEntity", b =>
                {
                    b.Property<int>("PermissionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PermissionId"));

                    b.Property<string>("PermissionDescription")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("PermissionName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("PermissionId");

                    b.ToTable("Permissions");
                });

            modelBuilder.Entity("POSSystem.Domain.Entities.common.ReportEntity", b =>
                {
                    b.Property<int>("ReportId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReportId"));

                    b.Property<string>("ReportName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("TotalOrders")
                        .HasColumnType("int");

                    b.Property<int>("TotalPurchases")
                        .HasColumnType("int");

                    b.Property<int>("TotalSales")
                        .HasColumnType("int");

                    b.HasKey("ReportId");

                    b.ToTable("Reports");
                });

            modelBuilder.Entity("POSSystem.Domain.Entities.common.RoleEntity", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoleId"));

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("RoleId");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("POSSystem.Domain.Entities.common.UserEntity", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("AdminId")
                        .HasColumnType("int");

                    b.Property<int?>("CashierId")
                        .HasColumnType("int");

                    b.Property<int?>("CustomerId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("UserId");

                    b.HasIndex("CustomerId")
                        .IsUnique()
                        .HasFilter("[CustomerId] IS NOT NULL");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("PermissionEntityRoleEntity", b =>
                {
                    b.Property<int>("PermissionsPermissionId")
                        .HasColumnType("int");

                    b.Property<int>("RolesRoleId")
                        .HasColumnType("int");

                    b.HasKey("PermissionsPermissionId", "RolesRoleId");

                    b.HasIndex("RolesRoleId");

                    b.ToTable("RolePermission", (string)null);
                });

            modelBuilder.Entity("POSSystem.Domain.Entities.AdminEntity", b =>
                {
                    b.HasOne("POSSystem.Domain.Entities.common.UserEntity", "User")
                        .WithOne("Admin")
                        .HasForeignKey("POSSystem.Domain.Entities.AdminEntity", "AdminId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("POSSystem.Domain.Entities.CashierEntity", b =>
                {
                    b.HasOne("POSSystem.Domain.Entities.common.UserEntity", "User")
                        .WithOne("Cashier")
                        .HasForeignKey("POSSystem.Domain.Entities.CashierEntity", "CashierId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("POSSystem.Domain.Entities.OrderProductEntity", b =>
                {
                    b.HasOne("POSSystem.Domain.Entities.common.OrderEntity", "Order")
                        .WithMany("OrderPro")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("POSSystem.Domain.Entities.common.InventoryEntity", "Product")
                        .WithMany("ProductOr")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("POSSystem.Domain.Entities.common.OrderEntity", b =>
                {
                    b.HasOne("POSSystem.Domain.Entities.CustomerEntity", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("POSSystem.Domain.Entities.common.UserEntity", b =>
                {
                    b.HasOne("POSSystem.Domain.Entities.CustomerEntity", "Customer")
                        .WithOne("User")
                        .HasForeignKey("POSSystem.Domain.Entities.common.UserEntity", "CustomerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("POSSystem.Domain.Entities.common.RoleEntity", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId");

                    b.Navigation("Customer");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("PermissionEntityRoleEntity", b =>
                {
                    b.HasOne("POSSystem.Domain.Entities.common.PermissionEntity", null)
                        .WithMany()
                        .HasForeignKey("PermissionsPermissionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("POSSystem.Domain.Entities.common.RoleEntity", null)
                        .WithMany()
                        .HasForeignKey("RolesRoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("POSSystem.Domain.Entities.CustomerEntity", b =>
                {
                    b.Navigation("Orders");

                    b.Navigation("User");
                });

            modelBuilder.Entity("POSSystem.Domain.Entities.common.InventoryEntity", b =>
                {
                    b.Navigation("ProductOr");
                });

            modelBuilder.Entity("POSSystem.Domain.Entities.common.OrderEntity", b =>
                {
                    b.Navigation("OrderPro");
                });

            modelBuilder.Entity("POSSystem.Domain.Entities.common.RoleEntity", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("POSSystem.Domain.Entities.common.UserEntity", b =>
                {
                    b.Navigation("Admin");

                    b.Navigation("Cashier");
                });
#pragma warning restore 612, 618
        }
    }
}
