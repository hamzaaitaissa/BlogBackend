using AutoMapper;
using blogfolio.Dto.User;
using blogfolio.Entities;
using blogfolio.Repositories;
using Microsoft.AspNetCore.Identity;

namespace blogfolio.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IPasswordHasher<User> _passwordHasher;

        public UserService(IUserRepository userRepository, IMapper mapper, IPasswordHasher<User> passwordHasher )
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _passwordHasher = passwordHasher;
        }

        public async Task<User> CreateUserAsync(CreateUserDto createUserDto)
        {
            //TODO: chack if user already exists
            var existingUser = await _userRepository.GetByEmailAsync(createUserDto.Email);
            if (existingUser != null)
            {
                throw new InvalidOperationException("A user with the same Email is already registred");
            }
            var user = _mapper.Map<User>(createUserDto);
            user.HashedPassword = _passwordHasher.HashPassword(user, createUserDto.HashedPassword);
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
