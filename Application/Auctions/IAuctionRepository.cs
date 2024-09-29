using Domain;

namespace Auctions.Application.Auctions
{
    public interface IAuctionRepository
    {
        public Task<Auction> GetByIdAsync(int auctionId);
        public Task<IEnumerable<Auction>> GetAllAsync();
        public Task CreateAsync(Auction auction);
        public Task ChangeAsync(Auction auction);
        public Task CancelAsync(int auctionId);    
    }

}
