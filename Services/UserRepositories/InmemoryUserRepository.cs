using JWT.Models;

namespace JWT.Services.UserRepositories;

public class InmemoryUserRepository : IUserRepository
{
    private readonly List<User> _user = new List<User>();

    public Task<User> Create(User user)
    {
        user.Id = Guid.NewGuid();
        _user.Add(user);
        return Task.FromResult(user);
    }

    public Task<User> GetByEmail(string email)
    {
        return Task.FromResult(_user.FirstOrDefault(u => u.Email == email));
    }

    public Task<User> GetById(Guid userId)
    {
        return Task.FromResult(_user.FirstOrDefault(u => u.Id == userId));
    }

    public Task<User> GetByUsername(string username)
    {
       return Task.FromResult(_user.FirstOrDefault(u => u.Username == username));
    }
}