using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace OSDL.Entities
{
    public partial class StoreDBContext : DbContext
    {
        public StoreDBContext()
        {
        }

        public StoreDBContext(DbContextOptions<StoreDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Inventory> Inventories { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderItem> OrderItems { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductCategory> ProductCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("address");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Inventory>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.LocationId).HasColumnName("locationID");

                entity.Property(e => e.ProductId).HasColumnName("productID");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.Inventories)
                    .HasForeignKey(d => d.LocationId)
                    .HasConstraintName("FK__Inventori__locat__00DF2177");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Inventories)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__Inventori__produ__7FEAFD3E");
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("address");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CustId).HasColumnName("custID");

                entity.Property(e => e.LocId).HasColumnName("locID");

                entity.HasOne(d => d.Cust)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustId)
                    .HasConstraintName("FK__Orders__custID__65370702");

                entity.HasOne(d => d.Loc)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.LocId)
                    .HasConstraintName("FK__Orders__locID__662B2B3B");
            });

            modelBuilder.Entity<OrderItem>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.OrderId).HasColumnName("orderID");

                entity.Property(e => e.ProductId).HasColumnName("productID");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderItems)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK__OrderItem__order__04AFB25B");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.OrderItems)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__OrderItem__produ__05A3D694");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Category).HasColumnName("category");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.Shortname)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("shortname");

                entity.HasOne(d => d.CategoryNavigation)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.Category)
                    .HasConstraintName("FK__Products__catego__74794A92");
            });

            modelBuilder.Entity<ProductCategory>(entity =>
            {
                entity.ToTable("productCategories");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Category)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("category");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
