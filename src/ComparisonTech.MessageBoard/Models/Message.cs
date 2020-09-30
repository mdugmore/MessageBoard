using System;

namespace ComparisonTech.MessageBoard.Models
{
    public class Message
    {
        
        public int MessageId { get; set; }
        public string MessageContent { get; set; }
        public DateTime Created { get; set; }
    }
}