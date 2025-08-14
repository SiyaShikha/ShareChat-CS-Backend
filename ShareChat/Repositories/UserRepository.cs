using Microsoft.EntityFrameworkCore;
using ShareChat.Data;
using ShareChat.Models;

namespace ShareChat.Repositories;

public class UserRepository(ChatDbContext dbContext) : IUserRepository
{
  private readonly ChatDbContext _dbContext = dbContext;

  public async Task<bool> IsUserRegistered(string username)
  {
    return await _dbContext.Users.AnyAsync(u => u.Username == username);
  }
  
  public async Task<User?> FindUser(string username)
  {
    return await _dbContext.Users.SingleOrDefaultAsync(u => u.Username == username);
  }

  public async Task AddUser(User user)
  {
    _dbContext.Users.Add(user);
    await _dbContext.SaveChangesAsync();
  }
  
  public async Task<User?> GetUserById(int userId)
  {
    return await _dbContext.Users.FindAsync(userId);
  }
}