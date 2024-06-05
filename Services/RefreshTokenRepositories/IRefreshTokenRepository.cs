using JWT.Models;

namespace JWT.Services.RefreshTokenRepositories;

public interface IRefreshTokenRepository
{
    Task Create(RefreshToken refreshToken);
    Task Delete(Guid id);
    Task DeleteAll(Guid userId);
    Task<RefreshToken> GetByToken(string token);

}
