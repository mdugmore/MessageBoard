using System;
using System.Linq;
using System.Threading.Tasks;
using ComparisonTech.MessageBoard.Models;
using ComparisonTech.MessageBoard.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ComparisonTech.MessageBoard.Controllers
{
    [Route("api/[controller]")] 
    [ApiController]
    public class MessagesController : Controller
    {
        private readonly MessageBoardContext _context;

        public MessagesController(MessageBoardContext context)
        {
            _context = context;
            
            //Used for seeded data in InMemory data
            _context.Database.EnsureCreated();
        }
        
        [HttpGet("{messageId}")]
        public ActionResult<Message> GetMessage(int messageId)
        {
            var message = _context.Messages.Find(messageId);
            
            if (message == null) return NotFound(messageId);
            
            return Ok(message);
        }
        
        [HttpGet]
        public async Task<ActionResult<PaginatedList<Message>>> GetMessages(int daysInPast = 30, int? pageNumber = 1, int pageSize = 5)
        {
            var messages = _context.Messages.Where(m => (DateTime.Now - m.Created).TotalDays < daysInPast);

            return Ok(await PaginatedList<Message>.CreateAsync(messages.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        [HttpPost]
        public ActionResult<Message> PostMessage([FromBody]CreateMessageRequest createMessageRequest)
        {
            var message = new Message
            {
                MessageContent = createMessageRequest.MessageContents,
                Created = DateTime.Now
            };

            _context.Messages.Add(message);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetMessage), new { messageId = message.MessageId }, message);
        }
    }
}