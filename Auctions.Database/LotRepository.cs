using Auctions.Application.Auctions;
using Auctions.Application.Lots;
using Database;
using Domain;

namespace Auctions.Database
{
    public class LotRepository : ILotRepository, IDisposable
    {
        private readonly ApplicationDbContext _dbContext;

        public LotRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;

        }
        public Task<IEnumerable<Lot>> GetAllAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task CreateAsync(Lot lot, CancellationToken cancellationToken)
        {
            var lotEntity = new LotEntity
            {
                Id = lot.Id,
                Name = lot.Name,
                AuctionId = lot.AuctionId,
                Status = (LotStatusEntity?)lot.Status,
            };
            _dbContext.Set<LotEntity>().Add(lotEntity);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public Task ChangeAsync(Guid auctionId, string name, DateTime dateStart, DateTime dateEnd, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task CancelAsync(Guid auctionId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
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
