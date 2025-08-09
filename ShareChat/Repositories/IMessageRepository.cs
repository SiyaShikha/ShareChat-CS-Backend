using ShareChat.Models;

namespace ShareChat.Repositories;

public interface IMessageRepository
{
  Task<List<Message>> GetMessagesByRoomId(int roomId);
  Task AddMessage(Message message);
}