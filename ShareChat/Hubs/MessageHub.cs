using Microsoft.AspNetCore.SignalR;

namespace ShareChat.Hubs;

public class MessageHub : Hub
{
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

  public async Task SendMessage(int roomId, string text)
  {
    await Clients.Group($"room-{roomId}")
      .SendAsync("ReceiveMessage", new
      {
        Text = text,
        RoomId = roomId,
        Timestamp = DateTime.UtcNow
      });
  }
}