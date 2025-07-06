using System.ComponentModel.DataAnnotations;

namespace ShareChat.Models;

public class ChatRoom
{
  public int Id { get; init; }
  
  [Required]
  [MaxLength(50)]
  public string Name { get; set; } = string.Empty;
  
  public ICollection<User> Users { get; set; } = new List<User>();
  public ICollection<Message> Messages { get; set; } = new List<Message>();
}