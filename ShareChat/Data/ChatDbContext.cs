using Microsoft.EntityFrameworkCore;
using ShareChat.Models;

namespace ShareChat.Data;

public class ChatDbContext : DbContext
{
  public ChatDbContext(DbContextOptions<ChatDbContext> options) : base(options) { }
  
  public DbSet<User> Users { get; set; }
  public DbSet<Message> Messages { get; set; }
  public DbSet<ChatRoom> ChatRooms { get; set; }
  public DbSet<ChatRoomUser> ChatRoomUsers { get; set; }
  
  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<ChatRoomUser>()
            .HasKey(cru => new { cru.RoomId, cru.UserId }); // composite PK

        modelBuilder.Entity<ChatRoomUser>()
            .HasOne(cru => cru.ChatRoom)
            .WithMany(cr => cr.ChatRoomUsers)
            .HasForeignKey(cru => cru.RoomId);

        modelBuilder.Entity<ChatRoomUser>()
            .HasOne(cru => cru.User)
            .WithMany(u => u.ChatRoomUsers)
            .HasForeignKey(cru => cru.UserId);
  }
}