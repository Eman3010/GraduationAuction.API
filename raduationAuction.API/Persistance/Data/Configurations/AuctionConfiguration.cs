﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using raduationAuction.API.Model;

namespace GraduationAuction.API.Persistance.Data.Configurations
{
    public class AuctionConfiguration : IEntityTypeConfiguration<Auction>
    {
        public void Configure(EntityTypeBuilder<Auction> builder)
        {
            builder.HasOne(A => A.item)
                   .WithOne(I => I.Auction)
                   .HasForeignKey<Auction>(A => A.itemid);


            builder.HasMany(a => a.biddings)
              .WithOne(b => b.auction)
              .HasForeignKey(b => b.Auctionid);


            builder.Property(a => a.StartingPrice)
                   .HasColumnType("decimal(18,2)")
                   .IsRequired();

            builder.Property(a => a.CurrentPrice)
                   .HasColumnType("decimal(18,2)");
        }
    }
}
