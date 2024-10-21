using Domain;

namespace Auctions.Application.Auctions
{
    public interface IAuctionRepository
    {
        public Task<IEnumerable<Auction>> GetAllAsync(CancellationToken cancellationToken);
        public Task CreateAsync(Auction auction, CancellationToken cancellationToken);
        public Task ChangeAsync(int auctionId, string name, DateTime dateStart, DateTime dateEnd, CancellationToken cancellationToken);
        public Task CancelAsync(int auctionId, CancellationToken cancellationToken);
    }

}
