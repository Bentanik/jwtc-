using JWT.Models;

namespace JWT.Services.RefreshTokenRepositories;

public class InMemoryRefreshTokenRepository : IRefreshTokenRepository
{
    private readonly List<RefreshToken> _refreshTokens = new List<RefreshToken>(); 
    public Task Create(RefreshToken refreshToken)
    {
        refreshToken.Id = Guid.NewGuid();
        _refreshTokens.Add(refreshToken);
        return Task.CompletedTask;
    }

    public Task<RefreshToken> GetByToken(string token)
    {
        RefreshToken refreshToken = _refreshTokens.FirstOrDefault(x => x.Token == token);
        return  Task.FromResult(refreshToken);
    }

    public Task Delete(Guid Id)
    {
        _refreshTokens.RemoveAll(r => r.Id == Id);
        return Task.CompletedTask;
    }

    public Task DeleteAll(Guid userId)
    {
        _refreshTokens.RemoveAll(r => r.UserId == userId);
        return Task.CompletedTask;
    }
}
