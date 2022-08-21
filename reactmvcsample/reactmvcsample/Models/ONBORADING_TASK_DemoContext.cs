using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace reactmvcsample.Models
{
    public partial class ONBORADING_TASK_DemoContext : DbContext
    {
        public ONBORADING_TASK_DemoContext()
        {
        }

        public ONBORADING_TASK_DemoContext(DbContextOptions<ONBORADING_TASK_DemoContext> options)
            : base()
        {
        }

        public virtual DbSet<CustomerTable> CustomerTables { get; set; } = null!;
        public virtual DbSet<ProductTable> ProductTables { get; set; } = null!;
        public virtual DbSet<SalesTable> SalesTables { get; set; } = null!;
        public virtual DbSet<StoreTable> StoreTables { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustomerTable>(entity =>
            {
                entity.ToTable("Customer_Table");

                entity.HasIndex(e => e.Name, "UQ__Customer__737584F6D41087F5")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Address)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ProductTable>(entity =>
            {
                entity.ToTable("Product_Table");

                entity.HasIndex(e => e.Name, "UQ__Product___737584F6F50D1F26")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SalesTable>(entity =>
            {
                entity.ToTable("Sales_Table");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.DateSold).HasColumnType("date");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.SalesTables)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__Sales_Tab__Custo__2D27B809");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.SalesTables)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__Sales_Tab__Produ__2E1BDC42");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.SalesTables)
                    .HasForeignKey(d => d.StoreId)
                    .HasConstraintName("FK__Sales_Tab__Store__2F10007B");
            });

            modelBuilder.Entity<StoreTable>(entity =>
            {
                entity.ToTable("Store_Table");

                entity.HasIndex(e => e.Name, "UQ__Store_Ta__737584F6802B86E0")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Address)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
