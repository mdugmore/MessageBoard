using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComparisonTech.MessageBoard.Models
{
    public class Message
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MessageId { get; set; }
        
        [Required]
        public string MessageContent { get; set; }
        public DateTime Created { get; set; }
        public string CreatedBy { get; set; }
    }
}