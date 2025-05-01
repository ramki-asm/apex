using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using APEX.Common.Models;

namespace APEX.Services.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(User user);
        ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
    }
}
