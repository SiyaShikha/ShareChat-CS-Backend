using System.Security.Cryptography;
using System.Text;
using ShareChat.Models;
using ShareChat.DTOs;

using ShareChat.Repositories;

namespace ShareChat.Services;

public class UserService(IUserRepository repository)
{
  public async Task<bool> Register(RegisterDto dto)
  {
    if (await repository.IsUserRegistered(dto.Username))
    {
      return false;
    }

    var user = new User
    {
      Username = dto.Username,
      PasswordHash = ComputeHash(dto.Password)
    };

    await repository.AddUser(user);
    return true;
  }
  
  public async Task<bool> Login(LoginDto dto)
  {
    var registeredUser = await repository.FindUser(dto.Username);
    if (registeredUser == null)
    {
      return false;
    }

    var hashedInput = ComputeHash(dto.Password);
    return registeredUser.PasswordHash == hashedInput;
    // TODO: Return JWT token in next step
  }
  
  private string ComputeHash(string password)
  {
    using var sha256 = SHA256.Create();
    var bytes = Encoding.UTF8.GetBytes(password);
    var hash = sha256.ComputeHash(bytes);
    return Convert.ToBase64String(hash);
  }
}