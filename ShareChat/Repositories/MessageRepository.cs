using Microsoft.EntityFrameworkCore;
using ShareChat.Data;
using ShareChat.Models;

namespace ShareChat.Repositories;

public class MessageRepository : IMessageRepository
{
  private readonly ChatDbContext _context;

  public MessageRepository(ChatDbContext context)
  {
    _context = context;
  }

  public async Task<List<Message>> GetMessagesByRoomId(int roomId)
  {
    return await _context.Messages
      .Where(m => m.ChatRoomId == roomId)
      .Include(m => m.User)
      .OrderBy(m => m.Timestamp)
      .ToListAsync();
  }

  public async Task AddMessage(Message message)
  {
    _context.Messages.Add(message);
    await _context.SaveChangesAsync();
  }
}