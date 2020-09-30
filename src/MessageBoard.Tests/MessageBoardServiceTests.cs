using System;
using System.Threading.Tasks;
using ComparisonTech.MessageBoard.Data;
using ComparisonTech.MessageBoard.Models;
using ComparisonTech.MessageBoard.Models.DTO;
using ComparisonTech.MessageBoard.Services;
using FakeItEasy;
using FluentAssertions;
using Xunit;

namespace MessageBoard.Tests
{
    public class MessageBoardServiceTests
    {
        [Fact]
        public void GetMessage_Should_GetMessage()
        {
            //Arrange
            const int messageId = 1;
            var testMessage = new Message {MessageId = messageId, CreatedBy = "TestUser", Created = DateTime.Now.AddHours(-1)};
            var fakeMessageBoardRepository = A.Fake<IMessageBoardRepository>();

            A.CallTo(() => fakeMessageBoardRepository.GetMessage(messageId)).Returns(testMessage);
            
            var messageService = new MessageService(fakeMessageBoardRepository);
            
            //Act
            var returnedMessage = messageService.GetMessage(messageId);

            //Assert
            returnedMessage.Should().Be(testMessage);
            A.CallTo(() => fakeMessageBoardRepository.GetMessage(messageId)).MustHaveHappened(1, Times.Exactly);
        }
        
        [Fact]
        public async Task GetMessages_Should_GetMessages()
        {
            //Arrange
            var getMessageRequest = new GetMessagesRequest();
            var fakeMessageBoardRepository = A.Fake<IMessageBoardRepository>();
            
            var messageService = new MessageService(fakeMessageBoardRepository);
            
            //Act
            var returnedMessages = await messageService.GetMessages(getMessageRequest);

            //Assert
            A.CallTo(() => fakeMessageBoardRepository.GetMessages(getMessageRequest)).MustHaveHappened(1, Times.Exactly);
        }
        
        [Fact]
        public async Task CreateMessage_Should_CreateMessage()
        {
            //Arrange
            var createMessageRequest = new CreateMessageRequest
            {
                MessageContents = "This is a test message"
            };
            
            const string username = "TestUser";
            var testMessage = new Message {MessageId = 1, CreatedBy = "TestUser", Created = DateTime.Now.AddHours(-1), MessageContent = "Test Message"};
            
            var getMessageRequest = new GetMessagesRequest();
            var fakeMessageBoardRepository = A.Fake<IMessageBoardRepository>();
            A.CallTo(() => fakeMessageBoardRepository.CreateMessage(username, createMessageRequest)).Returns(testMessage);
            
            var messageService = new MessageService(fakeMessageBoardRepository);
            
            //Act
            var createdMessage = messageService.CreateMessage(username, createMessageRequest);

            //Assert
            A.CallTo(() => fakeMessageBoardRepository.CreateMessage(username, createMessageRequest)).MustHaveHappened(1, Times.Exactly);
            createdMessage.Should().Be(testMessage);
        }
    }
};