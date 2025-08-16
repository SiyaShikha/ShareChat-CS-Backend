using ShareChat.DTOs;
using ShareChat.Models;

namespace ShareChat.Services;

public interface IMessageService
{
  Task<List<MessageResponseDto>> GetMessagesByRoomId(int roomId);
  Task<MessageResponseDto> CreateMessage(int roomId, int userId, MessageDto dto);
}