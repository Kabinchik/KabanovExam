using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace KabanovExam.Models;

public partial class KabanovExamContext : DbContext
{
    public KabanovExamContext()
    {
    }

    public KabanovExamContext(DbContextOptions<KabanovExamContext> options)
        : base(options)
    {
    }

    public virtual DbSet<MaterialType> MaterialTypes { get; set; }

    public virtual DbSet<Partner> Partners { get; set; }

    public virtual DbSet<PartnersType> PartnersTypes { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductType> ProductTypes { get; set; }

    public virtual DbSet<Sale> Sales { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-A928918\\SQLEXPRESS;Database=KabanovExam;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MaterialType>(entity =>
        {
            entity.HasKey(e => e.MaterialType_ID);

            entity.ToTable("MaterialType");

            entity.Property(e => e.ProcentBraka).HasColumnType("decimal(5, 4)");
            entity.Property(e => e.TipMateriala)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Partner>(entity =>
        {
            entity.HasKey(e => e.Partners_ID);

            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Familiya)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Gorod)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.INN)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Imya)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Index)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.NaimenovaniePartnera)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Oblast)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Otchestvo)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Telephone)
                .HasMaxLength(13)
                .IsUnicode(false);
            entity.Property(e => e.Ulica)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.PartnersType).WithMany(p => p.Partners)
                .HasForeignKey(d => d.PartnersType_ID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Partners_PartnersType");
        });

        modelBuilder.Entity<PartnersType>(entity =>
        {
            entity.HasKey(e => e.PartnersType_ID);

            entity.ToTable("PartnersType");

            entity.Property(e => e.TipPartnera)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Products_ID);

            entity.Property(e => e.Artikul)
                .HasMaxLength(8)
                .IsUnicode(false);
            entity.Property(e => e.MinStoimost).HasColumnType("decimal(7, 2)");
            entity.Property(e => e.NaimenovanieProdukcii)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.ProductType).WithMany(p => p.Products)
                .HasForeignKey(d => d.ProductType_ID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Products_ProductType");
        });

        modelBuilder.Entity<ProductType>(entity =>
        {
            entity.HasKey(e => e.ProductType_ID);

            entity.ToTable("ProductType");

            entity.Property(e => e.Koefficient).HasColumnType("decimal(4, 2)");
            entity.Property(e => e.TipProdukcii)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Sale>(entity =>
        {
            entity.HasKey(e => e.Sales_ID);

            entity.HasOne(d => d.Partners).WithMany(p => p.Sales)
                .HasForeignKey(d => d.Partners_ID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Sales_Partners");

            entity.HasOne(d => d.Products).WithMany(p => p.Sales)
                .HasForeignKey(d => d.Products_ID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Sales_Products");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
