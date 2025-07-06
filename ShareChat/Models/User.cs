using System.ComponentModel.DataAnnotations;

namespace ShareChat.Models;

public class User
{
  public int Id { get; init; }
  
  [Required]
  [MaxLength(50)]
  public string Username { get; set; } = string.Empty;
  
  [Required]
  [MaxLength(50)]
  public string PasswordHash { get; set; } = string.Empty;

  public ICollection<ChatRoom> ChatRooms { get; set; } = new List<ChatRoom>();
  public ICollection<Message> Messages { get; set; } = new List<Message>();
}
