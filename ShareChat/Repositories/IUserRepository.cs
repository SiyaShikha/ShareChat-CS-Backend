using ShareChat.Models;

namespace ShareChat.Repositories;

public interface IUserRepository
{
  Task<bool> IsUserRegistered(string user);
  Task<User?> FindUser(string username);
  Task AddUser(User user);
  Task<User?> GetUserById(int userId);
}