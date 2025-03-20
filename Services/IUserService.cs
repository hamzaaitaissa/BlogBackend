using blogfolio.Dto.User;
using blogfolio.Entities;

namespace blogfolio.Services
{
    public interface IUserService
    {
        Task<User> CreateUserAsync(CreateUserDto createUserDto);
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task UpdateUserAsync(UpdateUserDto updateUserDto);
        Task DeleteUserAsync(int id);
        Task<User> GetUserByIdAsync(int id);
    }
}
