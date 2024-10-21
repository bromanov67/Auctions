using Domain;

namespace Auctions.Application.Lots
{
    public interface ILotRepository
    {
        public Task<IEnumerable<Lot>> GetAllAsync(CancellationToken cancellationToken);

        public Task<IEnumerable<Lot>> GetAllByAuctionIdAsync(int auctionId, CancellationToken cancellationToken);

        public Task CreateAsync(Lot lot, CancellationToken cancellationToken);
        public Task ChangeAsync(int lotId, string lotName, string descriprtion, DateTime dateStart, DateTime dateEnd,
            decimal betStep, decimal minPrice, decimal? ransomPrice, CancellationToken cancellationToken);

        public Task CancelAsync(int lotId, CancellationToken cancellationToken);
    }
}
