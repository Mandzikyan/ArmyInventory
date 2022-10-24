﻿// <auto-generated />
using System;
using Data.Dbcontext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Data.Migrations
{
    [DbContext(typeof(InventoryContext))]
    partial class InventoryContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:Collation", "Russian_Russia.utf8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("Data.Models.Category", b =>
                {
                    b.Property<string>("Categoryname")
                        .HasColumnType("character varying")
                        .HasColumnName("categoryname");

                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.HasKey("Categoryname")
                        .HasName("category_pkey");

                    b.HasIndex(new[] { "Id" }, "category_id_key")
                        .IsUnique();

                    b.ToTable("category");
                });

            modelBuilder.Entity("Data.Models.Description", b =>
                {
                    b.Property<string>("Barcode")
                        .HasColumnType("character varying")
                        .HasColumnName("barcode");

                    b.Property<int?>("Capacity")
                        .HasColumnType("integer")
                        .HasColumnName("capacity");

                    b.Property<string>("Categoryname")
                        .IsRequired()
                        .HasColumnType("character varying")
                        .HasColumnName("categoryname");

                    b.Property<decimal?>("Distance")
                        .HasColumnType("numeric")
                        .HasColumnName("distance");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("character varying")
                        .HasColumnName("name");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric")
                        .HasColumnName("price");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer")
                        .HasColumnName("quantity");

                    b.Property<decimal>("Weight")
                        .HasColumnType("numeric")
                        .HasColumnName("weight");

                    b.HasKey("Barcode")
                        .HasName("Description_pkey");

                    b.HasIndex(new[] { "Categoryname" }, "IX_description_categoryname");

                    b.HasIndex(new[] { "Barcode" }, "description_barcode_key")
                        .IsUnique();

                    b.ToTable("description");
                });

            modelBuilder.Entity("Data.Models.Description", b =>
                {
                    b.HasOne("Data.Models.Category", "CategorynameNavigation")
                        .WithMany()
                        .HasForeignKey("Categoryname")
                        .HasConstraintName("description_categoryname_fkey")
                        .IsRequired();

                    b.Navigation("CategorynameNavigation");
                });
#pragma warning restore 612, 618
        }
    }
}
