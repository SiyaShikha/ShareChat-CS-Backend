using ShareChat.DTOs;
using ShareChat.Models;

namespace ShareChat.Services;

public interface IChatRoomService
{
  public Task<List<ChatRoom>> GetAllChatRooms();
  public Task<ChatRoom?> GetChatRoomById(int roomId);
  public Task<ChatRoom> CreateChatRoom(ChatRoomDto dto);
  Task DeleteChatRoom(int id);
}