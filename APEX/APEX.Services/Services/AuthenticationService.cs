using APEX.Common.Models;
using APEX.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace APEX.Services.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly ITokenService _tokenService;

        public AuthenticationService(
            IUserRepository userRepository,
            IPasswordHasher passwordHasher,
            ITokenService tokenService)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _tokenService = tokenService;
        }

        public async Task<AuthenticationResult> AuthenticateAsync(string username, string password)
        {
            var user = await _userRepository.GetUserByUsernameAsync(username);

            if (user == null || !user.IsActive)
                return new AuthenticationResult { ErrorMessage = "Invalid credentials" };

            if (!_passwordHasher.VerifyPassword(password, user.PasswordHash, user.Salt))
                return new AuthenticationResult { ErrorMessage = "Invalid credentials" };

            user.LastLoginDate = DateTime.UtcNow;
            await _userRepository.UpdateAsync(user);

            var token = _tokenService.GenerateToken(user);

            return new AuthenticationResult
            {
                IsSuccess = true,
                User = user,
                Token = token
            };
        }

        public async Task<AuthenticationResult> RefreshTokenAsync(string token)
        {
            var principal = _tokenService.GetPrincipalFromExpiredToken(token);
            var username = principal.Identity.Name;
            var user = await _userRepository.GetUserByUsernameAsync(username);

            if (user == null || !user.IsActive)
                return new AuthenticationResult { ErrorMessage = "Invalid token" };

            var newToken = _tokenService.GenerateToken(user);

            return new AuthenticationResult
            {
                IsSuccess = true,
                User = user,
                Token = newToken
            };
        }

        public async Task LogoutAsync()
        {
            // Implementation for logout (e.g., token invalidation)
            await Task.CompletedTask;
        }

        public async Task<bool> HasPermissionAsync(string permission)
        {
            // Implementation for permission checking
            return await Task.FromResult(true);
        }
    }
}