using Domain;

namespace Auctions.Application.Auctions
{
    public interface IAuctionRepository
    {
        public Task<IEnumerable<Auction>> GetAllAsync();
        public Task CreateAsync(Auction auction);
        public Task ChangeAsync(Auction auction);
        public Task CancelAsync(Guid auctionId);    
    }

}
