using ShareChat.DTOs;
using ShareChat.Models;
using ShareChat.Repositories;

namespace ShareChat.Services;

public class MessageService : IMessageService
{
  private readonly IMessageRepository _messageRepo;

  public MessageService(IMessageRepository messageRepo)
  {
    _messageRepo = messageRepo;
  }

  public async Task<List<Message>> GetMessagesByRoomId(int roomId)
  {
    return await _messageRepo.GetMessagesByRoomId(roomId);
  }

  public async Task<Message> CreateMessage(int roomId, int userId, MessageDto dto)
  {
    var message = new Message
    {
      ChatRoomId = roomId,
      UserId = userId,
      Content = dto.Text,
      Timestamp = DateTime.UtcNow
    };

    await _messageRepo.AddMessage(message);
    return message;
  }
}