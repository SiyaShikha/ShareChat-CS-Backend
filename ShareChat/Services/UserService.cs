using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using ShareChat.Models;
using ShareChat.DTOs;

using ShareChat.Repositories;

namespace ShareChat.Services;

public class UserService : IUserService
{
  private readonly IUserRepository _repository;
  private readonly IConfiguration _config;

  public UserService(IUserRepository repository, IConfiguration config)
  {
    _repository = repository;
    _config = config;
  }
  public async Task<bool> Register(RegisterDto dto)
  {
    if (await _repository.IsUserRegistered(dto.Username))
    {
      return false;
    }

    var user = new User
    {
      Username = dto.Username,
      PasswordHash = ComputeHash(dto.Password)
    };

    await _repository.AddUser(user);
    return true;
  }
  
  public async Task<string?> Login(LoginDto dto)
  {
    var user = await _repository.FindUser(dto.Username);
    if (user == null) return null;

    var hashedInput = ComputeHash(dto.Password);
    if (user.PasswordHash != hashedInput) return null;

    // Create JWT Token
    var claims = new[]
    {
      new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
      new Claim(ClaimTypes.Name, user.Username)
    };

    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]!));
    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

    var token = new JwtSecurityToken(
      issuer: _config["Jwt:Issuer"],
      audience: _config["Jwt:Audience"],
      claims: claims,
      expires: DateTime.Now.AddHours(1),
      signingCredentials: creds
    );

    return new JwtSecurityTokenHandler().WriteToken(token);
  }
  
  private string ComputeHash(string password)
  {
    using var sha256 = SHA256.Create();
    var bytes = Encoding.UTF8.GetBytes(password);
    var hash = sha256.ComputeHash(bytes);
    return Convert.ToBase64String(hash);
  }
}