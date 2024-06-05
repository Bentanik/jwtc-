using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using JWT.Models;
using JWT.Services.TokenGenerators;
using Microsoft.IdentityModel.Tokens;

namespace JWT.Services.TokenGenrators;

public class AccessTokenGenrator
{
    private readonly AuthenticationConfiguration _configuration;
    private readonly TokenGenerator _tokenGenerators;
    public AccessTokenGenrator(AuthenticationConfiguration configuration, TokenGenerator tokenGenerators)
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
        return _tokenGenerators.GenerateToken(_configuration.AccessTokenSecret, _configuration.Issuer, _configuration.Audience, _configuration.AccessTokenExpirationMinutes, claims);
    }
}