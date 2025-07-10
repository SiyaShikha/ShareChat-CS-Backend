using ShareChat.DTOs;

namespace ShareChat.Services;

public interface IUserService
{
  public Task<bool> Register(RegisterDto dto);
  public Task<string?> Login(LoginDto dto);
}