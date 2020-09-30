using System.Threading.Tasks;
using ComparisonTech.MessageBoard.Models;
using ComparisonTech.MessageBoard.Models.DTO;
using ComparisonTech.MessageBoard.Services;
using Microsoft.AspNetCore.Mvc;

namespace ComparisonTech.MessageBoard.Controllers
{
    [Route("api/[controller]")] 
    [ApiController]
    public class MessagesController : Controller
    {
        private readonly IMessageService _messageService;

        public MessagesController(IMessageService messageService)
        {
            _messageService = messageService;
        }
        
        [HttpGet("{messageId}")]
        public ActionResult<Message> GetMessage(int messageId)
        {
            var message = _messageService.GetMessage(messageId);
            
            if (message == null) return NotFound(messageId);
            
            return Ok(message);
        }
        
        [HttpGet]
        public async Task<ActionResult<PaginatedList<Message>>> GetMessages([FromQuery]GetMessagesRequest getMessagesRequest)
        {
            return Ok(await _messageService.GetMessages(getMessagesRequest));
        }

        [HttpPost]
        public ActionResult<Message> PostMessage([FromBody]CreateMessageRequest createMessageRequest)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            
            //TODO: use authenticated user
            var messageCreatedBy = Request.HttpContext.Connection.Id;

            var newMessage = _messageService.CreateMessage(messageCreatedBy, createMessageRequest);
            
            return CreatedAtAction(nameof(GetMessage), new { messageId = newMessage.MessageId }, newMessage);
        }
    }
}