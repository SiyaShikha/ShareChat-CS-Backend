using Microsoft.AspNetCore.Mvc;
using ShareChat.DTOs;
using ShareChat.Models;
using ShareChat.Services;

namespace ShareChat.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
  private readonly IUserService _service;

  public UserController(IUserService service)
  {
    _service = service;
  }
  
  [HttpPost("register")]
  public async Task<IActionResult> Register([FromBody] RegisterDto dto)
  {
    if (!await _service.Register(dto))
    {
      return BadRequest("Username already exists.");
    }

    return Ok("User registered successfully.");
  }
  
  [HttpPost("login")]
  public async Task<IActionResult> Login([FromBody] LoginDto dto)
  {
    var token = await _service.Login(dto);
    if (token == null)
      return BadRequest("Username or password is incorrect.");
    
    Console.WriteLine($">>>>>>>>{token}");

    Response.Cookies.Append("authToken", token, new CookieOptions
    {
      HttpOnly = true,
      Secure = true,
      SameSite = SameSiteMode.None,
      Expires = DateTime.UtcNow.AddDays(7),
      Path = "/"
    });

    return Ok(new {message = "Successfully logged in!"});
  }
}