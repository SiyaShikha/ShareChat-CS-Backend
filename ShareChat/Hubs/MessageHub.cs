using System.Security.Claims;
using Microsoft.AspNetCore.SignalR;
using ShareChat.DTOs;
using ShareChat.Services;

namespace ShareChat.Hubs;

public class MessageHub : Hub
{
  private readonly IMessageService _messageService;

  public MessageHub(IMessageService messageService)
  {
    _messageService = messageService;
  }
  public override async Task OnConnectedAsync()
  {
    Console.WriteLine("Client connected: " + Context.ConnectionId);
    await base.OnConnectedAsync();
  }

  public override async Task OnDisconnectedAsync(Exception? exception)
  {
    Console.WriteLine("Client disconnected: " + Context.ConnectionId);

    // TODO: Update ChatRoomUser.IsActive = false
    // TODO: Remove from ChatRoomUsers if needed

    await base.OnDisconnectedAsync(exception);
  }

  public async Task JoinRoom(int roomId)
  {
    await Groups.AddToGroupAsync(Context.ConnectionId, $"room-{roomId}");
    Console.WriteLine($"Client joined room {roomId}: {Context.ConnectionId}");
  }

  public async Task SendMessage(int roomId, MessageDto dto)
  {
    var userId = int.Parse(Context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
    var userName = Context.User.FindFirst(ClaimTypes.Name)?.Value;
    var timestamp = DateTime.UtcNow;
    
    var message = await _messageService.CreateMessage(roomId, userId, dto);
    
    await Clients.Group($"room-{roomId}")
      .SendAsync("ReceiveMessage", new
      {
        content = dto.Text,
        userId,
        userName,
        timestamp
      });
  }
}