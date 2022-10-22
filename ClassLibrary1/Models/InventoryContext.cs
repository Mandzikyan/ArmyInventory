using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ClassLibrary1.Models
{
    public partial class InventoryContext : DbContext
    {
        public InventoryContext()
        {
        }

        public InventoryContext(DbContextOptions<InventoryContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Description> Descriptions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Host=localhost;Database=Inventory;Username=postgres;Password=Dav553715");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Russian_Russia.utf8");

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.Categoryname)
                    .HasName("category_pkey");

                entity.ToTable("category");

                entity.HasIndex(e => e.Id, "category_id_key")
                    .IsUnique();

                entity.Property(e => e.Categoryname)
                    .HasColumnType("character varying")
                    .HasColumnName("categoryname");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");
            });

            modelBuilder.Entity<Description>(entity =>
            {
                entity.HasKey(e => e.Categoryname)
                    .HasName("description_fkey");

                entity.ToTable("description");

                entity.HasIndex(e => e.Categoryname, "IX_description_categoryname");

                entity.HasIndex(e => e.Barcode, "description_barcode_key")
                    .IsUnique();

                entity.Property(e => e.Categoryname)
                    .HasColumnType("character varying")
                    .HasColumnName("categoryname");

                entity.Property(e => e.Barcode)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("barcode");

                entity.Property(e => e.Capacity).HasColumnName("capacity");

                entity.Property(e => e.Distance).HasColumnName("distance");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("name");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.Weight).HasColumnName("weight");

                entity.HasOne(d => d.CategorynameNavigation)
                    .WithOne(p => p.Description)
                    .HasForeignKey<Description>(d => d.Categoryname)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("description_categoryname_fkey");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
