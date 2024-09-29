using Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Auctions.Database.Configurations
{
    public class AuctionConfiguration : IEntityTypeConfiguration<AuctionEntity>
    {
        public void Configure(EntityTypeBuilder<AuctionEntity> builder)
        {
            builder.HasKey(a => a.Id);

            builder
                .HasOne(a => a.UserEntity)
                .WithMany(a => a.Auctions);

            builder
                .HasMany(a => a.Lots)
                .WithOne(a => a.AuctionEntity)
                .HasForeignKey(a => a.AuctionId);

        }
    }
}
