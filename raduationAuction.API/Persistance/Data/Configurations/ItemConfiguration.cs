using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using raduationAuction.API.Model;

namespace raduationAuction.API.Persistance.Data.Configurations
{
    public class ItemConfiguration : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.HasOne(i => i.category)
                  .WithMany(c => c.Items)
                   .HasForeignKey(i => i.categoryId)
                  .OnDelete(DeleteBehavior.NoAction);
        }
    }

}
