using Auctions.Application.Auctions;
using Database;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Auctions.Database
{
    public class AuctionRepository : IAuctionRepository, IDisposable
    {
        private readonly ApplicationDbContext _dbContext;

        public AuctionRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<IEnumerable<Auction>> GetAllAsync() 
        {
            var auctionEntities = await _dbContext.Set<AuctionEntity>().ToListAsync();
            return auctionEntities.Select(e => new Auction
            {
                Id = e.Id,
                Name = e.Name,
                UserId = e.UserId,
                DateStart = e.DateStart,
                DateEnd = e.DateEnd
            }).ToList();
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

        public async Task CancelAsync(Guid auctionId)
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

