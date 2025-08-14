using ShareChat.DTOs;
using ShareChat.Models;
using ShareChat.Utils;

namespace ShareChat.Services;

public interface IChatRoomService
{
  public Task<List<ChatRoom>> GetAllChatRooms();
  public Task<ChatRoom?> GetChatRoomById(int roomId);
  public Task<ChatRoom> CreateChatRoom(ChatRoomDto dto);
  Task DeleteChatRoom(int id);
  Task<JoinRoomResult> JoinChatRoom(int roomId, int userId);
  Task<bool> LeaveChatRoom(int roomId, int userId);
}