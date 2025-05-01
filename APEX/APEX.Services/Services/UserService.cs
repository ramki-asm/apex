using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APEX.Common.Models;
using APEX.Services.Interfaces;
using APEX.Services.Repositories;

namespace APEX.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;

        public UserService(IUserRepository userRepository, IPasswordHasher passwordHasher)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _userRepository.GetByIdAsync(id);
        }

        public async Task<User> GetUserByUsernameAsync(string username)
        {
            return await _userRepository.GetUserByUsernameAsync(username);
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _userRepository.GetAllUsersWithRolesAsync();
        }

        public async Task CreateUserAsync(User user, string password)
        {
            var (hash, salt) = _passwordHasher.CreatePasswordHash(password);
            user.PasswordHash = hash;
            user.Salt = salt;
            user.CreatedDate = DateTime.UtcNow;

            await _userRepository.AddAsync(user);
        }

        public async Task UpdateUserAsync(User user)
        {
            user.ModifiedDate = DateTime.UtcNow;
            await _userRepository.UpdateAsync(user);
        }

        public async Task DeleteUserAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user != null)
            {
                await _userRepository.DeleteAsync(user);
            }
        }
    }
}
