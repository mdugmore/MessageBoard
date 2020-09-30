using System;
using System.Collections.Generic;
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
            var testUser = "TestUser";
            var messageList = new List<Message>();
            
            for (var i = 1; i < 50; i++)
            {
                messageList.Add(new Message
                {
                    MessageId = i,
                    MessageContent = $"Message for MessageId: {i}",
                    CreatedBy = testUser,
                    Created = DateTime.Now.AddDays(-(i*2))
                });
            }
            
            modelBuilder.Entity<Message>().HasData(messageList);
        }
        
        public DbSet<Message> Messages { get; set; }
    }
}