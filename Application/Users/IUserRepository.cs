using Domain;

namespace Auctions.Application.Users
{
    public interface IUserRepository
    {
        public Task<Domain.User> GetByIdAsync(int userId);
        public Task<IEnumerable<Domain.User>> GetAllAsync();
        public Task CreateAsync(Domain.User auction);
        public Task ChangeAsync(Domain.User auction);
        public Task CancelAsync(int userId);
    }

}
