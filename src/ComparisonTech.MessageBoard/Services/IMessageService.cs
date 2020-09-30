using System.Collections.Generic;
using System.Threading.Tasks;
using ComparisonTech.MessageBoard.Models;
using ComparisonTech.MessageBoard.Models.DTO;

namespace ComparisonTech.MessageBoard.Services
{
    public interface IMessageService
    {
        Message GetMessage(int messageId);
        Task<ICollection<Message>> GetMessages(GetMessagesRequest getMessagesRequest);
        Message CreateMessage(string messageCreator, CreateMessageRequest createMessageRequest);
    }
}