using Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Auctions.Database.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.HasKey(u => u.Id);

            builder.
                HasMany(u => u.Auctions)
                .WithOne(u => u.UserEntity)
                .HasForeignKey(u => u.UserId);

            builder
                .HasMany(u => u.Bets)
                .WithOne(u => u.UserEntity)
                .HasForeignKey(u => u.UserId);
        }
    }
}
