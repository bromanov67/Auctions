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

        public async Task CancelAsync(Guid userId, CancellationToken cancellationToken)
        {
    /*        // Получаем аукцион по идентификатору
            var user = await _dbContext.Set<User>().FirstOrDefaultAsync(a => a.Id == userId);

            // Проверяем, что аукцион еще не был отменен
            if (uder?.IsCanceled ?? true)
            {
                throw new InvalidOperationException("Аукцион уже был отменен.");
            }

            // Отменяем аукцион
            user.IsCanceled = true;

            // Сохраняем изменения в базе данных
            await _dbContext.SaveChangesAsync();*/
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

    }

}

