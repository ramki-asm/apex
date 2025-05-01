using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IPasswordHasher
    {
        Tuple<string, string> CreatePasswordHash(string password);
        bool VerifyPassword(string password, string hash, string salt);
    }
}
