using Auctions.Application.Users;
using Database;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Auctions.Database
{
    public class UserRepository : IUserRepository, IDisposable
    {
        private readonly ApplicationDbContext _dbContext;

        public UserRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<User>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _dbContext.Set<User>().ToListAsync();
        }

        public async Task CreateAsync(User user, CancellationToken cancellationToken)
        {
            var userEntity = new UserEntity
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email

            };
            _dbContext.Set<UserEntity>().Add(userEntity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task ChangeAsync(User user, CancellationToken cancellationToken)
        {
            _dbContext.Set<User>().Update(user);
            await _dbContext.SaveChangesAsync();
        }

        public async Task CancelAsync(int userId, CancellationToken cancellationToken)
        {
            //TODO delete user from db
        }

        // TODO
        // read about dispose and IDisposable

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }

            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }

}

