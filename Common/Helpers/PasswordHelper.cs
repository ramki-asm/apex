using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using APEX.Common.Extemsion;

namespace APEX.Common.Helpers
{
    public static class PasswordHelper
    {
        public static (string Hash, string Salt) CreatePasswordHash(string password)
        {
            var salt = GenerateSalt();
            var hash = ComputeHash(password, salt);
            return (hash, salt);
        }

        public static bool VerifyPassword(string password, string hash, string salt)
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
            return combined.ToSha256();
        }
    }
}
