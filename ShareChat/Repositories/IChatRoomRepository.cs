using ShareChat.Models;

namespace ShareChat.Repositories;

public interface IChatRoomRepository
{
  Task<List<ChatRoom>> GetAllChatRooms();
  Task<ChatRoom?> GetChatRoomById(int id);
  Task<ChatRoom> AddChatRoom(ChatRoom room);
  Task DeleteChatRoom(ChatRoom room);
  Task UpdateChatRoom(ChatRoom room);
}