

namespace Auctions.Application.Users
{
    public interface IUserRepository
    {
        public Task<IEnumerable<Domain.User>> GetAllAsync(CancellationToken cancellationToken);
        public Task CreateAsync(Domain.User user, CancellationToken cancellationToken);
        public Task ChangeAsync(Domain.User user, CancellationToken cancellationToken);
        public Task CancelAsync(Guid userId, CancellationToken cancellationToken);
    }

}
