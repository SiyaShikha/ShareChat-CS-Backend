using ShareChat.DTOs;
using ShareChat.Models;
using ShareChat.Repositories;

namespace ShareChat.Services;

public class ChatRoomService : IChatRoomService
{
  private readonly IChatRoomRepository _repository;

  public ChatRoomService(IChatRoomRepository repository)
  {
    _repository = repository;
  }

  public async Task<List<ChatRoom>> GetAllChatRooms()
  {
    return await _repository.GetAllChatRooms();
  }

  public async Task<ChatRoom?> GetChatRoomById(int id)
  {
    return await _repository.GetChatRoomById(id);
  }

  public async Task<ChatRoom> CreateChatRoom(ChatRoomDto dto)
  {
    var room = new ChatRoom
    {
      Name = dto.Name,
    };

    await _repository.AddChatRoom(room);
    return room;
  }

  public async Task DeleteChatRoom(int id)
  {
    var room = await _repository.GetChatRoomById(id);
    if (room != null) await _repository.DeleteChatRoom(room);
  }
}