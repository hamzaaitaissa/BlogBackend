using AutoMapper;
using blogfolio.Dto.User;
using blogfolio.Entities;
using blogfolio.Repositories;

namespace blogfolio.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<User> CreateUserAsync(CreateUserDto createUserDto)
        {
            //TODO: chack if user already exists
            var user = _mapper.Map<User>(createUserDto);
            return await _userRepository.AddAsync(user);
        }

        public async Task DeleteUserAsync(int id)
        {
             await _userRepository.DeleteAsync(id);
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            return user;
        }

        public async Task UpdateUserAsync(UpdateUserDto updateUserDto)
        {
            var user = _mapper.Map<User>(updateUserDto);
            await _userRepository.UpdateAsync(user);
        }
    }
}
