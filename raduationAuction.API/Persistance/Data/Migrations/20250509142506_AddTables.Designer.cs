﻿// <auto-generated />
using System;
using GraduationAuction.API.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace raduationAuction.API.Persistance.Data.Migrations
{
    [DbContext(typeof(webDbContext))]
    [Migration("20250509142506_AddTables")]
    partial class AddTables
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("raduationAuction.API.Model.Auction", b =>
                {
                    b.Property<int>("AuctionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AuctionID"));

                    b.Property<decimal>("CurrentPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("StartingPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("itemid")
                        .HasColumnType("int");

                    b.Property<string>("pictureURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AuctionID");

                    b.HasIndex("itemid")
                        .IsUnique();

                    b.ToTable("Auctions");
                });

            modelBuilder.Entity("raduationAuction.API.Model.Bidding", b =>
                {
                    b.Property<int>("BiddingID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BiddingID"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Auctionid")
                        .HasColumnType("int");

                    b.Property<DateTime>("BidTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.HasKey("BiddingID");

                    b.HasIndex("Auctionid");

                    b.ToTable("Bids");
                });

            modelBuilder.Entity("raduationAuction.API.Model.Category", b =>
                {
                    b.Property<int>("CategoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryID"));

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryID");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("raduationAuction.API.Model.Item", b =>
                {
                    b.Property<int>("ItemID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ItemID"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("categoryId")
                        .HasColumnType("int");

                    b.HasKey("ItemID");

                    b.HasIndex("categoryId");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("raduationAuction.API.Model.Auction", b =>
                {
                    b.HasOne("raduationAuction.API.Model.Item", "item")
                        .WithOne("Auction")
                        .HasForeignKey("raduationAuction.API.Model.Auction", "itemid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("item");
                });

            modelBuilder.Entity("raduationAuction.API.Model.Bidding", b =>
                {
                    b.HasOne("raduationAuction.API.Model.Auction", "auction")
                        .WithMany("biddings")
                        .HasForeignKey("Auctionid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("auction");
                });

            modelBuilder.Entity("raduationAuction.API.Model.Item", b =>
                {
                    b.HasOne("raduationAuction.API.Model.Category", "category")
                        .WithMany("Items")
                        .HasForeignKey("categoryId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("category");
                });

            modelBuilder.Entity("raduationAuction.API.Model.Auction", b =>
                {
                    b.Navigation("biddings");
                });

            modelBuilder.Entity("raduationAuction.API.Model.Category", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("raduationAuction.API.Model.Item", b =>
                {
                    b.Navigation("Auction")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
