using System.Collections.Generic;
using System.Threading.Tasks;
using ComparisonTech.MessageBoard.Data;
using ComparisonTech.MessageBoard.Models;
using ComparisonTech.MessageBoard.Models.DTO;

namespace ComparisonTech.MessageBoard.Services
{
    public class MessageService : IMessageService
    {
        private readonly IMessageBoardRepository _messageBoardRepository;
        
        public MessageService(IMessageBoardRepository messageBoardRepository)
        {
            _messageBoardRepository = messageBoardRepository;
        }
        
        public Message GetMessage(int messageId)
        {
            return _messageBoardRepository.GetMessage(messageId);
        }

        public async Task<ICollection<Message>> GetMessages(GetMessagesRequest getMessagesRequest)
        {
            return await _messageBoardRepository.GetMessages(getMessagesRequest);
        }

        public Message CreateMessage(string messageCreator, CreateMessageRequest createMessageRequest)
        {
            return _messageBoardRepository.CreateMessage(messageCreator, createMessageRequest);
        }
    }
}