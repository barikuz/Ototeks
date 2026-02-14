using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Ototeks.Entities;

namespace Ototeks.DataAccess.Concrete;

public partial class OtoteksContext : DbContext
{
    public OtoteksContext()
    {
    }

    public OtoteksContext(DbContextOptions<OtoteksContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Color> Colors { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<DefectType> DefectTypes { get; set; }

    public virtual DbSet<Fabric> Fabrics { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderItem> OrderItems { get; set; }

    public virtual DbSet<ProductType> ProductTypes { get; set; }

    public virtual DbSet<QualityLog> QualityLogs { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlite(DatabaseHelper.GetConnectionString());
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Color>(entity =>
        {
            entity.HasKey(e => e.ColorId);

            entity.HasIndex(e => e.ColorName).IsUnique();

            entity.Property(e => e.ColorId).HasColumnName("ColorID");
            entity.Property(e => e.ColorName).HasMaxLength(50);
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId);

            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.Address).HasMaxLength(250);
            entity.Property(e => e.CustomerName).HasMaxLength(100);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Phone).HasMaxLength(20);
        });

        modelBuilder.Entity<DefectType>(entity =>
        {
            entity.HasKey(e => e.DefectId);

            entity.HasIndex(e => e.DefectName).IsUnique();

            entity.Property(e => e.DefectId).HasColumnName("DefectID");
            entity.Property(e => e.DefectName).HasMaxLength(50);
        });

        modelBuilder.Entity<Fabric>(entity =>
        {
            entity.HasKey(e => e.FabricId);

            entity.HasIndex(e => e.FabricCode).IsUnique();

            entity.Property(e => e.FabricId).HasColumnName("FabricID");
            entity.Property(e => e.ColorId).HasColumnName("ColorID");
            entity.Property(e => e.FabricCode).HasMaxLength(50);
            entity.Property(e => e.FabricName).HasMaxLength(100);
            entity.Property(e => e.StockQuantity)
                .HasDefaultValue(0m)
                .HasColumnType("REAL");

            // Set null on delete: removing a Color sets Fabric.ColorId to null
            entity.HasOne(d => d.Color).WithMany(p => p.Fabrics)
                .HasForeignKey(d => d.ColorId)
                .OnDelete(DeleteBehavior.SetNull);
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId);

            entity.HasIndex(e => e.OrderNumber).IsUnique();

            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.DueDate).HasColumnType("TEXT");
            entity.Property(e => e.OrderDate)
                .HasColumnType("TEXT");
            entity.Property(e => e.OrderNumber).HasMaxLength(20);
            entity.Property(e => e.OrderStatus)
                .HasDefaultValue(OrderStatus.Pending)
                .HasConversion<int>(); // Store OrderStatus enum as integer

            // Set null on delete: removing a Customer sets Order.CustomerId to null
            entity.HasOne(d => d.Customer).WithMany(p => p.Orders)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.SetNull);
        });

        modelBuilder.Entity<OrderItem>(entity =>
        {
            entity.HasKey(e => e.OrderItemId);

            entity.Property(e => e.OrderItemId).HasColumnName("OrderItemID");
            entity.Property(e => e.CurrentStage)
                .HasDefaultValue(OrderStatus.Pending)
                .HasConversion<int>(); // Store OrderStatus enum as integer
            entity.Property(e => e.FabricId).HasColumnName("FabricID");
            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.ProcessedByUserId).HasColumnName("ProcessedByUserID");
            entity.Property(e => e.TypeId).HasColumnName("TypeID");

            // Set null on delete: removing a Fabric sets OrderItem.FabricId to null
            entity.HasOne(d => d.Fabric).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.FabricId)
                .OnDelete(DeleteBehavior.SetNull);

            // Cascade delete: deleting an Order removes all its OrderItems
            entity.HasOne(d => d.Order).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.Cascade);

            // Set null on delete: removing a User sets OrderItem.ProcessedByUserId to null
            entity.HasOne(d => d.ProcessedByUser).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.ProcessedByUserId)
                .OnDelete(DeleteBehavior.SetNull);

            // Set null on delete: removing a ProductType sets OrderItem.TypeId to null
            entity.HasOne(d => d.Type).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.TypeId)
                .OnDelete(DeleteBehavior.SetNull);
        });

        modelBuilder.Entity<ProductType>(entity =>
        {
            entity.HasKey(e => e.TypeId);

            entity.HasIndex(e => e.TypeName).IsUnique();

            entity.Property(e => e.TypeId).HasColumnName("TypeID");
            entity.Property(e => e.TypeName).HasMaxLength(50);
            entity.Property(e => e.RequiredFabricAmount)
                .HasDefaultValue(0m)
                .HasColumnType("REAL");
        });

        modelBuilder.Entity<QualityLog>(entity =>
        {
            entity.HasKey(e => e.LogId);

            entity.Property(e => e.LogId).HasColumnName("LogID");
            entity.Property(e => e.DefectId).HasColumnName("DefectID");
            entity.Property(e => e.ImagePath).HasMaxLength(500);
            entity.Property(e => e.InspectionDate)
                .HasColumnType("TEXT");
            entity.Property(e => e.OperatorNote).HasMaxLength(200);
            entity.Property(e => e.OrderItemId).HasColumnName("OrderItemID");

            // Set null on delete: removing a DefectType sets QualityLog.DefectId to null
            entity.HasOne(d => d.Defect).WithMany(p => p.QualityLogs)
                .HasForeignKey(d => d.DefectId)
                .OnDelete(DeleteBehavior.SetNull);

            // Cascade delete: deleting an OrderItem removes all its QualityLogs
            entity.HasOne(d => d.OrderItem).WithMany(p => p.QualityLogs)
                .HasForeignKey(d => d.OrderItemId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId);

            entity.HasIndex(e => e.Username).IsUnique();

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.FullName).HasMaxLength(100);
            entity.Property(e => e.Password).HasMaxLength(50);
            entity.Property(e => e.Role).HasMaxLength(20);
            entity.Property(e => e.Username).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
