using Microsoft.AspNetCore.Mvc;
using ShareChat.DTOs;
using ShareChat.Models;
using ShareChat.Services;

namespace ShareChat.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController(UserService service) : ControllerBase
{
  
  [HttpPost("register")]
  public async Task<IActionResult> Register([FromBody] RegisterDto dto)
  {
    if (!await service.Register(dto))
    {
      return BadRequest("Username already exists.");
    }

    return Ok("User registered successfully.");
  }
  
  [HttpPost("login")]
  public async Task<IActionResult> Login([FromBody] LoginDto dto)
  {
    if (!await service.Login(dto))
    {
      return BadRequest("Username or password is incorrect.");
    }

    return Ok("User logged in successfully.");
    
    // TODO: Return JWT token in next step
  }
  
  
}