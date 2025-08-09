using ShareChat.DTOs;
using ShareChat.Models;

namespace ShareChat.Services;

public interface IMessageService
{
  Task<List<Message>> GetMessagesByRoomId(int roomId);
  Task<Message> CreateMessage(int roomId, int userId, MessageDto dto);
}