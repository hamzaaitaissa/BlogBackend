using blogfolio.Data;
using blogfolio.Entities;
using Microsoft.EntityFrameworkCore;

namespace blogfolio.Repositories
{
    public class UserRepository: IUserRepository
    {
        private readonly BlogfolioContext _blogfolioContext;

        public UserRepository(BlogfolioContext blogfolioContext)
        {
            _blogfolioContext = blogfolioContext;
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            var user = await _blogfolioContext.Users.FirstOrDefaultAsync(u => u.Email == email);
            return user;
        }

        public async Task<User> AddAsync(User user)
        {
            await _blogfolioContext.Users.AddAsync(user);
            await _blogfolioContext.SaveChangesAsync();

            return user;

        }

        public async Task DeleteAsync(int id)
        {
            var user = await _blogfolioContext.Users.FindAsync(id);
            if (user != null)
            {
                _blogfolioContext.Users.Remove(user);
                await _blogfolioContext.SaveChangesAsync();
            }
        }

        public async Task<User> GetByIdAsync(int id)
        {
            var user = await _blogfolioContext.Users.FindAsync(id);
            if (user == null)
            {
                throw new KeyNotFoundException($"User with ID {id} not found.");
            }
            return user;
        }

        public async Task UpdateAsync(User user)
        {
            _blogfolioContext.Users.Update(user);
            await _blogfolioContext.SaveChangesAsync();
        }
    }
}
