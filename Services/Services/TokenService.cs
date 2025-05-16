using System;
 
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using APEX.Common.Models;
using APEX.Services.Interfaces;
 namespace APEX.Services.Services
{
    public class TokenService : ITokenService
    {
        private readonly string _secretKey;
        private readonly string _issuer;
        private readonly string _audience;
        private readonly int _tokenExpiryMinutes;

        public string GenerateToken(User user)
        {
            throw new NotImplementedException();
        }

        public ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
        {
            throw new NotImplementedException();
        }

        //public TokenService()
        //{
        //    // These should come from configuration
        //    _secretKey = "";
        //    _issuer = "APEX";
        //    _audience = "APEX_Users";
        //    _tokenExpiryMinutes = 120;
        //}

        //public string GenerateToken(User user)
        //{
        //    var tokenHandler = new JwtSecurityTokenHandler();
        //    var key = Encoding.ASCII.GetBytes(_secretKey);

        //    var tokenDescriptor = new SecurityTokenDescriptor
        //    {
        //        Subject = new ClaimsIdentity(new[]
        //        {
        //            new Claim(ClaimTypes.Name, user.Username),
        //            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
        //            new Claim(ClaimTypes.Role, user.Role?.Name ?? "User")
        //        }),
        //        //Expires = DateTime.UtcNow.AddMinutes(_tokenExpiryMinutes),
        //        //SigningCredentials = new SigningCredentials(
        //        //    new SymmetricSecurityKey(key),
        //        //    SecurityAlgorithms.HmacSha256Signature),
        //        //Issuer = _issuer,
        //        //Audience = _audience
        //    };

        //    var token = tokenHandler.CreateToken(tokenDescriptor);
        //    return tokenHandler.WriteToken(token);
        //}

        //public ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
        //{
        //    var tokenValidationParameters = new TokenValidationParameters
        //    {
        //        ValidateAudience = false,
        //        ValidateIssuer = false,
        //        ValidateIssuerSigningKey = true,
        //        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_secretKey)),
        //        ValidateLifetime = false
        //    };

        //    var tokenHandler = new JwtSecurityTokenHandler();
        //    var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out _);
        //    return principal;
        //}
    }
}