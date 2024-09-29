

namespace Auctions.Application.Users
{
    public interface IUserRepository
    {
        public Task<IEnumerable<Domain.User>> GetAllAsync();
        public Task CreateAsync(Domain.User user);
        public Task ChangeAsync(Domain.User user);
        public Task CancelAsync(Guid userId);
    }

}
