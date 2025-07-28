using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShareChat.DTOs;
using ShareChat.Services;

namespace ShareChat.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class ChatRoomController: ControllerBase
{
  private readonly IChatRoomService _service;

  public ChatRoomController(IChatRoomService service)
  {
    _service = service;
  }

  [HttpGet]
  public async Task<IActionResult> GetAllChatRooms()
  {
    return Ok(await _service.GetAllChatRooms());
  }
  
  [HttpGet("{id}")]
  public async Task<IActionResult> GetChatRoomById(int id)
  {
    var room = await _service.GetChatRoomById(id);
    if (room == null)
    {
      return NotFound();
    }

    var dto = new ChatRoomDto { Id = room.Id, Name = room.Name }; // Simple mapping
    return Ok(dto);
  }
  
  [HttpPost]
  public async Task<IActionResult> CreateChatRoom([FromBody] ChatRoomDto dto)
  {
    var room = await _service.CreateChatRoom(dto);
    
    return CreatedAtAction(
      nameof(GetChatRoomById),
      new { id = room.Id },        
      room
    );
  }

  [HttpDelete("{id}")]
  public async Task<IActionResult> DeleteChatRoom(int id)
  {
    await _service.DeleteChatRoom(id);
    return NoContent();
  }
}