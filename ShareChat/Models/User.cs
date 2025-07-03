namespace ShareChat.Models;

public class User
{
  public int Id { get; init; }
  public string? Username { get; set; }
  public string? PasswordHash { get; set; }
}