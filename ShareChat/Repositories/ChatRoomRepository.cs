using Microsoft.EntityFrameworkCore;
using ShareChat.Data;
using ShareChat.Models;

namespace ShareChat.Repositories;

public class ChatRoomRepository : IChatRoomRepository
{
  private readonly ChatDbContext _dbContext;

  public ChatRoomRepository(ChatDbContext dbContext)
  {
    _dbContext = dbContext;
  }
  
  public async Task<List<ChatRoom>> GetAllChatRooms()
  {
    return await _dbContext.ChatRooms.ToListAsync();
  }

  public async Task<ChatRoom?> GetChatRoomById(int id)
  {
    return await _dbContext.ChatRooms.FindAsync(id);
  }

  public async Task<ChatRoom> AddChatRoom(ChatRoom chatRoom)
  {
    _dbContext.ChatRooms.Add(chatRoom);
    await _dbContext.SaveChangesAsync();
    return chatRoom;
  }

  public async Task DeleteChatRoom(ChatRoom room)
  {
    _dbContext.ChatRooms.Remove(room);
    await _dbContext.SaveChangesAsync();
  }
}