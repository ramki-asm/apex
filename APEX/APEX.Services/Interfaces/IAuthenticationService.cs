using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APEX.Services.Interfaces
{
    public interface IAuthenticationService
    {
        //Task<AuthenticationResult> AuthenticateAsync(string username, string password);
      //  Task<AuthenticationResult> RefreshTokenAsync(string token);
        Task LogoutAsync();
        Task<bool> HasPermissionAsync(string permission);
    }
}
