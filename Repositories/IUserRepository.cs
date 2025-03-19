using blogfolio.Data;
using blogfolio.Entities;

namespace blogfolio.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetByIdAsync(int id);
        Task<User> AddAsync(User user);
        Task UpdateAsync(User user);
        Task DeleteAsync(int id);

        Task<User> GetByEmailAsync(string email);
    }
}
