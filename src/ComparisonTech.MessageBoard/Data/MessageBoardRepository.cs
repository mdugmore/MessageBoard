using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComparisonTech.MessageBoard.Models;
using ComparisonTech.MessageBoard.Models.DTO;
using Microsoft.EntityFrameworkCore;

namespace ComparisonTech.MessageBoard.Data
{
    public class MessageBoardRepository : IMessageBoardRepository
    {
        private readonly MessageBoardContext _context;
        
        public MessageBoardRepository(MessageBoardContext context)
        {
            _context = context;
            
            //Used for seeded data in InMemory data
            _context.Database.EnsureCreated();
        }
        
        public Message GetMessage(int messageId)
        {
            return _context.Messages.Find(messageId);
        }
        public async Task<ICollection<Message>> GetMessages(GetMessagesRequest getMessagesRequest)
        {
            var messages = _context.Messages.Where(m => (DateTime.Now - m.Created).TotalDays < getMessagesRequest.DaysInPast);

            return await PaginatedList<Message>.CreateAsync(messages.AsNoTracking(), getMessagesRequest.PageNumber, getMessagesRequest.PageSize);
        }

        public Message CreateMessage(string messageCreator, CreateMessageRequest createMessageRequest)
        {
            var message = new Message
            {
                MessageContent = createMessageRequest.MessageContents,
                Created = DateTime.Now,
                CreatedBy = messageCreator
            };

            _context.Messages.Add(message);
            _context.SaveChanges();

            return message;
        }
    }
}