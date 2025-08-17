namespace ShareChat.Models;

public class ChatRoomUser
{
  public int RoomId { get; set; }
  public ChatRoom? ChatRoom { get; set; }
  
  public int UserId { get; set; }
  public User? User { get; set; }
  
  public DateTime JoinedAt { get; set; }
  public DateTime LastSeenAt { get; set; }
  
  public bool IsAdmin { get; set; }
  
  public bool IsActive { get; set; }
}
