namespace ShareChat.DTOs;

public class MessageResponseDto
{
  public int Id { get; set; }
  public string? Content { get; set; }
  public DateTime Timestamp { get; set; }
  public int UserId { get; set; }
  public string? UserName { get; set; }
}