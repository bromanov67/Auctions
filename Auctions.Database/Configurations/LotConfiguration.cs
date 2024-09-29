using Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Auctions.Database.Configurations
{
    public class LotConfiguration : IEntityTypeConfiguration<LotEntity>
    {
        public void Configure(EntityTypeBuilder<LotEntity> builder)
        {
            builder.HasKey(l => l.Id);

            builder
                .HasMany(l => l.Bets)
                .WithOne(b => b.LotEntity)
                .HasForeignKey(b => b.LotId);

            builder
                .HasOne(l => l.AuctionEntity)
                .WithMany(a => a.Lots); 
        }
    }
}
