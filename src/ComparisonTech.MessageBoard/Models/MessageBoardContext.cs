using System;
using Microsoft.EntityFrameworkCore;


namespace ComparisonTech.MessageBoard.Models
{
    public class MessageBoardContext : DbContext
    {
        public MessageBoardContext (DbContextOptions<MessageBoardContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //TODO: Remove test seed data for production
            modelBuilder.Entity<Message>().HasData(
                new Message
                {
                    MessageId = 1,
                    MessageContent = "Message 1",
                    Created = DateTime.Now.AddDays(-35)
                },
                new Message
                {
                    MessageId = 2,
                    MessageContent = "Message 2",
                    Created = DateTime.Now.AddDays(-22)
                },
                new Message
                {
                    MessageId = 3,
                    MessageContent = "Message 3",
                    Created = DateTime.Now.AddDays(-10)
                },
                new Message
                {
                    MessageId = 4,
                    MessageContent = "Message 4",
                    Created = DateTime.Now.AddDays(-5)
                },
                new Message
                {
                    MessageId = 5,
                    MessageContent = "Message 5",
                    Created = DateTime.Now.AddDays(-1)
                },
                new Message
                {
                    MessageId = 6,
                    MessageContent = "Message 6",
                    Created = DateTime.Now
                }
            );
        }
        
        public DbSet<Message> Messages { get; set; }
    }
}