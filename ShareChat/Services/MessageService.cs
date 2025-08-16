using ShareChat.DTOs;
using ShareChat.Models;
using ShareChat.Repositories;

namespace ShareChat.Services;

public class MessageService : IMessageService
{
  private readonly IMessageRepository _messageRepository;
  private readonly IChatRoomRepository _chatRoomRepository;
  private readonly IUserRepository _userRepository;

  public MessageService(
    IMessageRepository messageRepository,
    IChatRoomRepository chatRoomRepository,
    IUserRepository userRepository)
  {
    _messageRepository = messageRepository;
    _chatRoomRepository = chatRoomRepository;
    _userRepository = userRepository;
  }

  public async Task<List<MessageResponseDto>> GetMessagesByRoomId(int roomId)
  {
    var room = await _chatRoomRepository.GetChatRoomById(roomId);
    if (room == null) throw new Exception("Chat room not found");

    var messages = await _messageRepository.GetMessagesByRoomId(roomId);
    var res = messages.Select((message) => new MessageResponseDto
    {
      Id = message.Id,
      Content = message.Content,
      Timestamp = message.Timestamp,
      UserId = message.UserId,
      UserName = message.User.Username,
    }).ToList();
    return res;
  }

  public async Task<MessageResponseDto> CreateMessage(int roomId, int userId, MessageDto dto)
  {
    var room = await _chatRoomRepository.GetChatRoomById(roomId);
    if (room == null) throw new Exception("Chat room not found");

    var user = await _userRepository.GetUserById(userId);
    if (user == null) throw new Exception("User not found");

    var message = new Message
    {
      Content = dto.Text,
      Timestamp = DateTime.UtcNow,
      ChatRoomId = roomId,
      UserId = userId
    };

    await _messageRepository.AddMessage(message);
   
    return new MessageResponseDto
    {
      Id = message.Id,
      Content = message.Content,
      Timestamp = message.Timestamp,
      UserId = message.UserId,
      UserName = message.User.Username,
    };
  }
}