using Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Auctions.Database.Configurations
{
    public class BetConfiguration : IEntityTypeConfiguration<BetEntity>
    {
        public void Configure(EntityTypeBuilder<BetEntity> builder)
        {
            builder.HasKey(b => b.Id);

            builder
                .HasOne(b => b.UserEntity)
                .WithMany(u => u.Bets);

            builder
                .HasOne(b => b.LotEntity)
                .WithMany(l => l.Bets);
        }
    }
}
