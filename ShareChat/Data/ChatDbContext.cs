using Microsoft.EntityFrameworkCore;
using ShareChat.Models;

namespace ShareChat.Data;

public class ChatDbContext : DbContext
{
  public ChatDbContext(DbContextOptions<ChatDbContext> options) : base(options) { }
  
  public DbSet<User> Users { get; set; }
  public DbSet<Message> Messages { get; set; }
  public DbSet<ChatRoom> ChatRooms { get; set; }
}