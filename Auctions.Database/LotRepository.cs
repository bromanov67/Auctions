using Auctions.Application.Lots;
using Database;
using Domain;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace Auctions.Database
{
    public class LotRepository : ILotRepository, IDisposable
    {
        private readonly ApplicationDbContext _dbContext;

        public LotRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;

        }
        public async Task<IEnumerable<Lot>> GetAllAsync(CancellationToken cancellationToken)
        {
            var lotEntities = await _dbContext.Set<LotEntity>().ToListAsync();
            return lotEntities.Select(e => new Lot
            {
                Name = e.Name,
                Id = e.Id,
                AuctionId = e.AuctionId,
                Description = e.Description,
                MinPrice = e.MinPrice,
                RansomPrice = e.RansomPrice,
                Status = (LotStatus)e.Status,
                Images = e.Images
            }).ToList();
        }

        public async Task CreateAsync(Lot lot, CancellationToken cancellationToken)
        {
            var lotEntity = new LotEntity
            {
                Id = lot.Id,
                Name = lot.Name,
                AuctionId = lot.AuctionId,
                Description = lot.Description,
                Status = (LotStatusEntity?)lot.Status,
                MinPrice = lot.MinPrice,
                RansomPrice = lot.RansomPrice,
            };
            _dbContext.Set<LotEntity>().Add(lotEntity);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task ChangeAsync(int lotId, string lotName, string descriprtion, DateTime dateStart, DateTime dateEnd,
                                decimal betStep, decimal minPrice, decimal? ransomPrice,CancellationToken cancellationToken)
        {
            var lotEntity = await _dbContext.Set<LotEntity>()
                .FirstOrDefaultAsync(a => a.Id == lotId, cancellationToken);

            if (lotEntity == null)
            {
                throw new InvalidOperationException($"Аукцион с id {lotId} не найден.");
            }

            lotEntity.MinPrice = minPrice;
            lotEntity.RansomPrice = ransomPrice;
            lotEntity.Description = descriprtion;
            lotEntity.Name = lotName;

            _dbContext.Lots?.Update(lotEntity);
            await _dbContext.SaveChangesAsync(cancellationToken);
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

        public Task CancelAsync(int lotId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
