using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using raduationAuction.API.Model;

namespace GraduationAuction.API.Persistance.Data.Configurations
{
    public class BiddingConfiguration : IEntityTypeConfiguration<Bidding>
    {
        public void Configure(EntityTypeBuilder<Bidding> builder)
        {
            //builder.HasOne(b => b.Buyer)
            //         .WithMany(u => u.biddings)
            //         .HasForeignKey(b => b.BuyerUserId)
            //         .OnDelete(DeleteBehavior.NoAction);

            builder.Property(b => b.BidTime)
                      .HasDefaultValueSql("GETDATE()")
                       .IsRequired();

            builder.Property(b => b.Amount)
                   .HasColumnType("decimal(18,2)");
        }
    }
}
