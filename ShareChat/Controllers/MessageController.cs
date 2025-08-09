using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShareChat.DTOs;
using ShareChat.Services;
using System.Security.Claims;

namespace ShareChat.Controllers;

[ApiController]
[Route("api/chatroom/{roomId:int}/[controller]")]
[Authorize]
public class MessageController : ControllerBase
{
  private readonly IMessageService _messageService;

  public MessageController(IMessageService messageService)
  {
    _messageService = messageService;
  }

  [HttpGet]
  public async Task<IActionResult> GetMessages(int roomId)
  {
    var messages = await _messageService.GetMessagesByRoomId(roomId);
    return Ok(messages);
  }

  [HttpPost]
  public async Task<IActionResult> SendMessage(int roomId, [FromBody] MessageDto dto)
  {
    var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
    var message = await _messageService.CreateMessage(roomId, userId, dto);
    return Ok(message);
  }
}