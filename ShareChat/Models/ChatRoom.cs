namespace ShareChat.Models;

public class ChatRoom
{
  public int Id { get; init; }
  public string? Name { get; set; }
  public ICollection<User>? Users { get; set; }
}