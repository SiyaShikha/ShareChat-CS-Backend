using System.ComponentModel.DataAnnotations;

namespace ShareChat.Models;

public class Message
{
  public int Id { get; set; }
  
  [Required]
  [MaxLength(100)]
  public string Content { get; set; } = null!;
  
  public int UserId { get; init; }
  public User User { get; set; } = null!;

  public int ChatRoomId { get; init; }
  public ChatRoom ChatRoom { get; set; } = null!;
  
  public DateTime Timestamp { get; init; }
}