using JWT.Models;
using JWT.Models.Responses;
using JWT.Services.RefreshTokenRepositories;
using JWT.Services.TokenGenerators;
using JWT.Services.TokenGenrators;
using JWT.Services.TokenValidators;

namespace JWT.Services.Authenticators;

public class Authenticator
{
    private readonly AccessTokenGenrator _accessTokenGenerator;
    private readonly RefreshTokenGenerator _refreshTokenGenerator;
    private readonly IRefreshTokenRepository _refreshTokenRepository;

    public Authenticator(AccessTokenGenrator accessTokenGenerator, RefreshTokenGenerator refreshTokenGenerator, IRefreshTokenRepository refreshTokenRepository)
    {
        _accessTokenGenerator = accessTokenGenerator;
        _refreshTokenGenerator = refreshTokenGenerator;
        _refreshTokenRepository = refreshTokenRepository;
    }

    public async Task<AuthenticatedUserResponse> Authenticate(User user)
    {
        string accessToken = _accessTokenGenerator.GenerateToken(user);
        string refreshToken = _refreshTokenGenerator.GenerateToken(user);

        RefreshToken refreshTokenDTO = new()
        {
            Token = refreshToken,
            UserId = user.Id,
        };

        await _refreshTokenRepository.Create(refreshTokenDTO);

        return new AuthenticatedUserResponse()
        {
            AccessToken = accessToken,
            RefreshToken = refreshToken
        };
    }
}

