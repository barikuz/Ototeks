using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Ototeks.Entities;
using Microsoft.Extensions.Configuration;
using System.IO;

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
            // 1. Ayar dosyasının yerini bul (Programın çalıştığı klasör)
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            // 2. Dosyayı oku
            IConfigurationRoot configuration = builder.Build();

            // 3. İçindeki 'OtoteksConn' anahtarını al
            var connectionString = configuration.GetConnectionString("OtoteksConn");

            // 4. Bağlantıyı kur
            optionsBuilder.UseSqlServer(connectionString);
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Color>(entity =>
        {
            entity.HasKey(e => e.ColorId).HasName("PK__Colors__8DA7676D72717B9C");

            entity.HasIndex(e => e.ColorName, "UQ__Colors__C71A5A7BC5AE552F").IsUnique();

            entity.Property(e => e.ColorId).HasColumnName("ColorID");
            entity.Property(e => e.ColorName).HasMaxLength(50);
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK__Customer__A4AE64B8C7D0F125");

            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.Address).HasMaxLength(250);
            entity.Property(e => e.CustomerName).HasMaxLength(100);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Phone).HasMaxLength(20);
        });

        modelBuilder.Entity<DefectType>(entity =>
        {
            entity.HasKey(e => e.DefectId).HasName("PK__DefectTy__144A37FC4AEEC627");

            entity.HasIndex(e => e.DefectName, "UQ__DefectTy__9409D72A7C0EE8CC").IsUnique();

            entity.Property(e => e.DefectId).HasColumnName("DefectID");
            entity.Property(e => e.DefectName).HasMaxLength(50);
        });

        modelBuilder.Entity<Fabric>(entity =>
        {
            entity.HasKey(e => e.FabricId).HasName("PK__Fabrics__3B1819CC9726A356");

            entity.HasIndex(e => e.FabricCode, "UQ__Fabrics__46E0325C57F6A26F").IsUnique();

            entity.Property(e => e.FabricId).HasColumnName("FabricID");
            entity.Property(e => e.ColorId).HasColumnName("ColorID");
            entity.Property(e => e.FabricCode).HasMaxLength(50);
            entity.Property(e => e.FabricName).HasMaxLength(100);
            entity.Property(e => e.StockQuantity)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Color).WithMany(p => p.Fabrics)
                .HasForeignKey(d => d.ColorId)
                .HasConstraintName("FK__Fabrics__ColorID__59063A47");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__Orders__C3905BAF1F7C6222");

            entity.HasIndex(e => e.OrderNumber, "UQ__Orders__CAC5E74398F5B81C").IsUnique();

            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.DueDate).HasColumnType("datetime");
            entity.Property(e => e.OrderDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.OrderNumber).HasMaxLength(20);
            entity.Property(e => e.OrderStatus)
                .HasMaxLength(20)
                .HasDefaultValue("Beklemede");

            entity.HasOne(d => d.Customer).WithMany(p => p.Orders)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK__Orders__Customer__5DCAEF64");
        });

        modelBuilder.Entity<OrderItem>(entity =>
        {
            entity.HasKey(e => e.OrderItemId).HasName("PK__OrderIte__57ED06A1395F2741");

            entity.Property(e => e.OrderItemId).HasColumnName("OrderItemID");
            entity.Property(e => e.CurrentStage)
                .HasMaxLength(50)
                .HasDefaultValue("Planlama");
            entity.Property(e => e.FabricId).HasColumnName("FabricID");
            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.ProcessedByUserId).HasColumnName("ProcessedByUserID");
            entity.Property(e => e.TypeId).HasColumnName("TypeID");

            entity.HasOne(d => d.Fabric).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.FabricId)
                .HasConstraintName("FK__OrderItem__Fabri__6383C8BA");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK__OrderItem__Order__628FA481");

            entity.HasOne(d => d.ProcessedByUser).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.ProcessedByUserId)
                .HasConstraintName("FK__OrderItem__Proce__66603565");

            entity.HasOne(d => d.Type).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.TypeId)
                .HasConstraintName("FK__OrderItem__TypeI__6477ECF3");
        });

        modelBuilder.Entity<ProductType>(entity =>
        {
            entity.HasKey(e => e.TypeId).HasName("PK__ProductT__516F03953125B8B9");

            entity.HasIndex(e => e.TypeName, "UQ__ProductT__D4E7DFA8BA321818").IsUnique();

            entity.Property(e => e.TypeId).HasColumnName("TypeID");
            entity.Property(e => e.TypeName).HasMaxLength(50);
        });

        modelBuilder.Entity<QualityLog>(entity =>
        {
            entity.HasKey(e => e.LogId).HasName("PK__QualityL__5E5499A86E79C6F8");

            entity.Property(e => e.LogId).HasColumnName("LogID");
            entity.Property(e => e.DefectId).HasColumnName("DefectID");
            entity.Property(e => e.ImagePath).HasMaxLength(500);
            entity.Property(e => e.InspectionDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.OperatorNote).HasMaxLength(200);
            entity.Property(e => e.OrderItemId).HasColumnName("OrderItemID");

            entity.HasOne(d => d.Defect).WithMany(p => p.QualityLogs)
                .HasForeignKey(d => d.DefectId)
                .HasConstraintName("FK__QualityLo__Defec__6B24EA82");

            entity.HasOne(d => d.OrderItem).WithMany(p => p.QualityLogs)
                .HasForeignKey(d => d.OrderItemId)
                .HasConstraintName("FK__QualityLo__Order__693CA210");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CCAC0B4E0F88");

            entity.HasIndex(e => e.Username, "UQ__Users__536C85E4A40874B6").IsUnique();

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
