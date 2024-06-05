using JWT.Models;
using Microsoft.EntityFrameworkCore;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    { }

    #region DbSet
    public DbSet<User> Users;
    public DbSet<RefreshToken> RefreshTokens;
    #endregion

    #region OnModelCreating
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    { }
    #endregion
}