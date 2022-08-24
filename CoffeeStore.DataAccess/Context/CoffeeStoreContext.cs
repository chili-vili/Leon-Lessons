﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using CoffeeStore.DataAccess.Models;

namespace CoffeeStore.DataAccess.Context
{
    public partial class CoffeeStoreContext : DbContext
    {
        public CoffeeStoreContext()
        {
        }

        public CoffeeStoreContext(DbContextOptions<CoffeeStoreContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Client> Clients { get; set; } = null!;
        public virtual DbSet<Operation> Operations { get; set; } = null!;
        public virtual DbSet<OperationType> OperationTypes { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<OrderDetail> OrderDetails { get; set; } = null!;
        public virtual DbSet<OrderStatus> OrderStatuses { get; set; } = null!;
        public virtual DbSet<Origin> Origins { get; set; } = null!;
        public virtual DbSet<Price> Prices { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<ProductOperation> ProductOperations { get; set; } = null!;
        public virtual DbSet<ProductProperty> ProductProperties { get; set; } = null!;
        public virtual DbSet<ProductPropertyValue> ProductPropertyValues { get; set; } = null!;
        public virtual DbSet<ProductType> ProductTypes { get; set; } = null!;
        public virtual DbSet<PropertyEnum> PropertyEnums { get; set; } = null!;
        public virtual DbSet<PropertyEnumValue> PropertyEnumValues { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-0PTM10I\\SQLEXPRESS;Database=CoffeeStore;Integrated Security=SSPI\n;TrustServerCertificate=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Client>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.DeliveryAddress).HasMaxLength(500);

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.PhoneNumber).HasMaxLength(20);

                entity.Property(e => e.Surname).HasMaxLength(200);
            });

            modelBuilder.Entity<Operation>(entity =>
            {
                entity.HasIndex(e => e.OperationType, "idx__operations__operation_type");

                entity.HasIndex(e => e.ProductId, "idx__operations_product_id");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.HasOne(d => d.OperationTypeNavigation)
                    .WithMany(p => p.Operations)
                    .HasForeignKey(d => d.OperationType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Operations_Operations");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Operations)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Operations_Products");
            });

            modelBuilder.Entity<OperationType>(entity =>
            {
                entity.ToTable("OperationType");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(20);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Orders_Clients");

                entity.HasOne(d => d.OrderStatusNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.OrderStatus)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Orders_OrderStatuses");
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Sum).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK_OrderDetails_Orders");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderDetails_Products");
            });

            modelBuilder.Entity<OrderStatus>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(30);
            });

            modelBuilder.Entity<Origin>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .HasMaxLength(10)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Price>(entity =>
            {
                entity.HasKey(e => new { e.ProductId, e.Date });

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.SellingPrice).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.VendorPrice).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Prices)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Prices_Products");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.Name).HasMaxLength(250);

                entity.Property(e => e.NomenclatureNumber).HasMaxLength(20);

                entity.HasOne(d => d.ProductType)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.ProductTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Products_ProductTypes");
            });

            modelBuilder.Entity<ProductOperation>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ProductOperations");

                entity.Property(e => e.Name).HasMaxLength(250);

                entity.Property(e => e.NomenclatureNumber).HasMaxLength(20);
            });

            modelBuilder.Entity<ProductProperty>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(200);

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductProperties)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductProperties_Products");
            });

            modelBuilder.Entity<ProductPropertyValue>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.PropertyId, e.ProductId });

                entity.Property(e => e.NumericValue).HasColumnType("numeric(28, 6)");

                entity.Property(e => e.StringValue).HasMaxLength(500);

                entity.HasOne(d => d.EnumValue)
                    .WithMany(p => p.ProductPropertyValues)
                    .HasForeignKey(d => d.EnumValueId)
                    .HasConstraintName("FK_ProductPropertyValues_EnumValues");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductPropertyValues)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductPropertyValues_Products");

                entity.HasOne(d => d.Property)
                    .WithMany(p => p.ProductPropertyValues)
                    .HasForeignKey(d => d.PropertyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductPropertyValues_ProductProperties");
            });

            modelBuilder.Entity<ProductType>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(100);
            });

            modelBuilder.Entity<PropertyEnum>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(100);
            });

            modelBuilder.Entity<PropertyEnumValue>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.NumericValue).HasColumnType("numeric(28, 6)");

                entity.Property(e => e.StringValue).HasMaxLength(200);

                entity.HasOne(d => d.Enum)
                    .WithMany(p => p.PropertyEnumValues)
                    .HasForeignKey(d => d.EnumId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EnumValues_Enums");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
