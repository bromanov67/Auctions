using Auctions.Application.Users;
using Database;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Auctions.Database
{
    public class UserRepository : IUserRepository, IDisposable
    {
        private readonly AuctionsDbContext _dbContext;

        public UserRepository(AuctionsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User> GetByIdAsync(int auctionId)
        {
            return await _dbContext.Set<User>().FirstOrDefaultAsync(a => a.Id == auctionId);
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _dbContext.Set<User>().ToListAsync();
        }

        public async Task CreateAsync(User auction)
        {
            var auctionEntity = new UserEntity
            {
                Id = auction.Id,
                Name = auction.Name,
                Email = auction.Email
  
            };
            await _dbContext.Set<UserEntity>().AddAsync(auctionEntity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task ChangeAsync(User auction)
        {
            _dbContext.Set<User>().Update(auction);
            await _dbContext.SaveChangesAsync();
        }

        public async Task CancelAsync(int auctionId)
        {
    /*        // Получаем аукцион по идентификатору
            var auction = await _dbContext.Set<User>().FirstOrDefaultAsync(a => a.Id == auctionId);

            // Проверяем, что аукцион еще не был отменен
            if (auction?.IsCanceled ?? true)
            {
                throw new InvalidOperationException("Аукцион уже был отменен.");
            }

            // Отменяем аукцион
            auction.IsCanceled = true;

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

