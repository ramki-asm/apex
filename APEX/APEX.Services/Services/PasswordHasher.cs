using System;
using System.Security.Cryptography;
using System.Text;
using APEX.Services.Interfaces;

namespace APEX.Services.Services
{
    public class PasswordHasher : IPasswordHasher
    {
        public (string Hash, string Salt) CreatePasswordHash(string password)
        {
            var salt = GenerateSalt();
            var hash = ComputeHash(password, salt);
            return (hash, salt);
        }

        public bool VerifyPassword(string password, string hash, string salt)
        {
            return ComputeHash(password, salt) == hash;
        }

        private static string GenerateSalt()
        {
            var bytes = new byte[16];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(bytes);
            }
            return Convert.ToBase64String(bytes);
        }

        private static string ComputeHash(string password, string salt)
        {
            var combined = string.Concat(password, salt);
            using (var sha = SHA256.Create())
            {
                var bytes = Encoding.UTF8.GetBytes(combined);
                var hash = sha.ComputeHash(bytes);
                return BitConverter.ToString(hash).Replace("-", "").ToLower();
            }
        }
    }
}