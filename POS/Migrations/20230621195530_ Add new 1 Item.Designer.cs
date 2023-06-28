﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using POS.Entity;

#nullable disable

namespace POS.Migrations
{
    [DbContext(typeof(POSDbContext))]
    [Migration("20230621195530_ Add new 1 Item")]
    partial class Addnew1Item
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("POS.Entity.Catagory", b =>
                {
                    b.Property<int>("catId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnOrder(0);

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("catId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("SubCatagoryId")
                        .HasColumnType("integer");

                    b.HasKey("catId");

                    b.HasIndex("SubCatagoryId");

                    b.ToTable("SalesMaster");
                });

            modelBuilder.Entity("POS.Entity.SalesM", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateOnly>("SalesDate")
                        .HasColumnType("date");

                    b.Property<int>("SalesNumber")
                        .HasColumnType("integer");

                    b.Property<bool>("Status")
                        .HasColumnType("boolean");

                    b.Property<double>("SubTotal")
                        .HasColumnType("double precision");

                    b.Property<double>("Tax")
                        .HasColumnType("double precision");

                    b.Property<double>("Total")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.ToTable("Sales");
                });

            modelBuilder.Entity("POS.Entity.SubCatagory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("CatagorycatId")
                        .HasColumnType("integer");

                    b.Property<int>("ItemId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CatagorycatId");

                    b.HasIndex("ItemId");

                    b.ToTable("SubCatagory");
                });

            modelBuilder.Entity("POS.Entity.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Pssword")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("POS.Models.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("SubCatagoryId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("SubCatagoryId");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("POS.Entity.Catagory", b =>
                {
                    b.HasOne("POS.Entity.SubCatagory", "subcatagory")
                        .WithMany()
                        .HasForeignKey("SubCatagoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("subcatagory");
                });

            modelBuilder.Entity("POS.Entity.SubCatagory", b =>
                {
                    b.HasOne("POS.Entity.Catagory", null)
                        .WithMany("subCatagories")
                        .HasForeignKey("CatagorycatId");

                    b.HasOne("POS.Models.Item", "item")
                        .WithMany()
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("item");
                });

            modelBuilder.Entity("POS.Models.Item", b =>
                {
                    b.HasOne("POS.Entity.SubCatagory", null)
                        .WithMany("items")
                        .HasForeignKey("SubCatagoryId");
                });

            modelBuilder.Entity("POS.Entity.Catagory", b =>
                {
                    b.Navigation("subCatagories");
                });

            modelBuilder.Entity("POS.Entity.SubCatagory", b =>
                {
                    b.Navigation("items");
                });
#pragma warning restore 612, 618
        }
    }
}
