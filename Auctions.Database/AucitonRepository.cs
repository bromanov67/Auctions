using Auctions.Application.Auctions;
using Database;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Auctions.Database
{
    public class AuctionRepository : IAuctionRepository, IDisposable
    {
        private readonly AuctionsDbContext _dbContext;

        public AuctionRepository(AuctionsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Auction> GetByIdAsync(int auctionId)
        {
            return await _dbContext.Set<Auction>().FirstOrDefaultAsync(a => a.Id == auctionId);
        }

        public async Task<IEnumerable<Auction>> GetAllAsync() 
        {
            return await _dbContext.Set<Auction>().ToListAsync();
        }

        public async Task CreateAsync(Auction auction )
        {
            var auctionEntity = new AuctionEntity
            {
                DateStart = auction.DateStart,
                Id = auction.Id,
                Name = auction.Name,
                UserId = auction.UserId,
                Status = (AuctionStatusEntity?)auction.Status,
                DateEnd = auction.DateEnd
            };
             _dbContext.Set<AuctionEntity>().Add(auctionEntity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task ChangeAsync(Auction auction)
        {
            _dbContext.Set<Auction>().Update(auction);
            await _dbContext.SaveChangesAsync();
        }

        public async Task CancelAsync(int auctionId)
        {
            // Получаем аукцион по идентификатору
            var auction = await _dbContext.Set<Auction>().FirstOrDefaultAsync(a => a.Id == auctionId);

            // Проверяем, что аукцион еще не был отменен
            if (auction?.IsCanceled ?? true)
            {
                throw new InvalidOperationException("Аукцион уже был отменен.");
            }

            // Отменяем аукцион
            auction.IsCanceled = true;

            // Сохраняем изменения в базе данных
            await _dbContext.SaveChangesAsync();
        }


        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }

}

