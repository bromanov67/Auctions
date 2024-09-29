using Auctions.Database.Configurations;
using Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Auctions.Database
{
    public class AuctionsDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public AuctionsDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public DbSet<LotEntity> lot { get; set; }

        public DbSet<AuctionEntity>? auction { get; set; }

        public DbSet<BetEntity>? bet { get; set; }

        public DbSet<UserEntity>? user { get; set; }

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AuctionConfiguration());
            modelBuilder.ApplyConfiguration(new BetConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new LotConfiguration());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_configuration.GetConnectionString("AuctionsDbContext"));
        }
    }
}
