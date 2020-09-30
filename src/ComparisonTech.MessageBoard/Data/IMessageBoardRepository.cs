using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComparisonTech.MessageBoard.Models;
using ComparisonTech.MessageBoard.Models.DTO;

namespace ComparisonTech.MessageBoard.Data
{
    public interface IMessageBoardRepository
    {
        Message GetMessage(int messageId);
        Task<ICollection<Message>> GetMessages(GetMessagesRequest getMessagesRequest);
        Message CreateMessage(string messageCreator, CreateMessageRequest createMessageRequest);
    }
}