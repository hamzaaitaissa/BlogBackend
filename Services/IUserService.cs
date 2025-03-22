using blogfolio.Dto.User;
using blogfolio.Entities;
using blogfolio.ENUMS;

namespace blogfolio.Services
{
    public interface IUserService
    {
        Task<User> CreateUserAsync(CreateUserDto createUserDto);
        Task<IEnumerable<UserWithBlogsDto>> GetAllUsersAsync();
        Task UpdateUserAsync(UpdateUserDto updateUserDto);
        Task DeleteUserAsync(int id);
        Task<User> GetUserByIdAsync(int id);
        Task<bool> UpdateUserRoleAsync(int userId, UserRole newRole);
    }
}
