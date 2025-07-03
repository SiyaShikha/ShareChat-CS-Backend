namespace ShareChat.Models;

public class Message
{
  public int Id { get; set; }
  public string? Content { get; set; }
  public int UserId { get; init; }
  public int ChatRoomId { get; init; }
  public DateTime Timestamp { get; init; }
}