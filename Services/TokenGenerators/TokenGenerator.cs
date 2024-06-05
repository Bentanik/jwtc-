using JWT.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JWT.Services.TokenGenerators
{
    public class TokenGenerator
    {
        public string GenerateToken(string secretKey, string issuer, string audience, double expirationMinutes, IEnumerable<Claim>? claims = null)
        {
            SecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            SigningCredentials credentials = new(key, SecurityAlgorithms.HmacSha256);

            JwtSecurityToken token = new(issuer, audience, claims, DateTime.UtcNow, DateTime.UtcNow.AddMinutes(expirationMinutes), credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
