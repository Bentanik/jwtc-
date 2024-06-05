using JWT.Services.Authenticators;
using JWT.Services.PasswordHasher;
using JWT.Services.RefreshTokenRepositories;
using JWT.Services.TokenGenerators;
using JWT.Services.TokenGenrators;
using JWT.Services.TokenValidators;
using JWT.Services.UserRepositories;

namespace JWT.DI;

public static class DI
{

    public static void AddWebAppDepdencyInjection(this IServiceCollection services)
    {
        services.AddSingleton<RefreshTokenValidator>();
        services.AddSingleton<AccessTokenGenrator>();
        services.AddSingleton<RefreshTokenGenerator>();
        services.AddSingleton<Authenticator>();
        services.AddSingleton<IRefreshTokenRepository, InMemoryRefreshTokenRepository>();
        services.AddSingleton<TokenGenerator>();
        services.AddSingleton<IPasswordHasher, BcryptPasswordHasher>();
        services.AddSingleton<IUserRepository, InmemoryUserRepository>();
    }
}