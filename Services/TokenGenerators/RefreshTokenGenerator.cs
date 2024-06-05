using JWT.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JWT.Services.TokenGenerators;
public class RefreshTokenGenerator
{
    private readonly AuthenticationConfiguration _configuration;
    private readonly TokenGenerator _tokenGenerators;
    public RefreshTokenGenerator(AuthenticationConfiguration configuration, TokenGenerator tokenGenerators)
    {
        _configuration = configuration;
        _tokenGenerators = tokenGenerators;
    }

    public string GenerateToken(User user)
    {
        SecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.AccessTokenSecret));
        SigningCredentials credentials = new(key, SecurityAlgorithms.HmacSha256);

        List<Claim> claims = new() {
            new Claim("id", user.Id.ToString()),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.Name, user.Username),
        };
        return _tokenGenerators.GenerateToken(_configuration.RefreshTokenSecret, _configuration.Issuer, _configuration.Audience, _configuration.RefreshTokenExpirationMinutes, claims);
    }
}
