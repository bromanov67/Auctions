using Domain;

namespace Auctions.Application.Auctions
{
    public interface IAuctionRepository
    {
        public Task<IEnumerable<Auction>> GetAllAsync(CancellationToken cancellationToken);
        public Task CreateAsync(Auction auction, CancellationToken cancellationToken);
        public Task ChangeAsync(Auction auction, CancellationToken cancellationToken);
        public Task CancelAsync(Guid auctionId, CancellationToken cancellationToken);    
    }

}
