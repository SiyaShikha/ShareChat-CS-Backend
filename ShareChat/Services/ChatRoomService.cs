using ShareChat.DTOs;
using ShareChat.Models;
using ShareChat.Repositories;
using ShareChat.Utils;

namespace ShareChat.Services;

public class ChatRoomService : IChatRoomService
{
  private readonly IChatRoomRepository _chatRoomRepo;
  private readonly IUserRepository _userRepo;

  public ChatRoomService(IChatRoomRepository chatRoomRepo, IUserRepository userRepo)
  {
    _chatRoomRepo = chatRoomRepo;
    _userRepo = userRepo;
  }

  public async Task<List<ChatRoom>> GetAllChatRooms()
  {
    return await _chatRoomRepo.GetAllChatRooms();
  }

  public async Task<ChatRoom?> GetChatRoomById(int id)
  {
    return await _chatRoomRepo.GetChatRoomById(id);
  }

  public async Task<ChatRoom> CreateChatRoom(ChatRoomDto dto)
  {
    var room = new ChatRoom
    {
      Name = dto.Name,
    };

    await _chatRoomRepo.AddChatRoom(room);
    return room;
  }

  public async Task DeleteChatRoom(int id)
  {
    var room = await _chatRoomRepo.GetChatRoomById(id);
    if (room != null) await _chatRoomRepo.DeleteChatRoom(room);
  }

  public async Task<JoinRoomResult> JoinChatRoom(int roomId, int userId)
  {
    var room = await _chatRoomRepo.GetChatRoomById(roomId);
    if (room == null)
      return JoinRoomResult.NotFound;

    if (await _chatRoomRepo.IsUserInRoom(roomId, userId))
      return JoinRoomResult.AlreadyJoined;

    var user = await _userRepo.GetUserById(userId);
    if (user == null)
      return JoinRoomResult.NotFound;
    
    await _chatRoomRepo.UpdateChatRoom(room);

    return JoinRoomResult.Success;
  }

  public Task<bool> LeaveChatRoom(int roomId, int userId)
  {
    throw new NotImplementedException();
  }
}