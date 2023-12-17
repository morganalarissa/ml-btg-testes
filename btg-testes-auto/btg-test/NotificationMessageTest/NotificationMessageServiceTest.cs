using btg_testes_auto.NotificationMessage;
using btg_testes_auto.Order;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;

namespace btg_test.NotificationMessageTest
{
    public class NotificationMessageServiceTest
    {
        private readonly IMessageService _mockMessageService;
        private NotificationMessageService _service;

        public NotificationMessageServiceTest()
        {
            _mockMessageService = Substitute.For<IMessageService>();
            _service = new NotificationMessageService(_mockMessageService);
        }

        [Fact]
        public void NotifyUsers_AllMessagesSent_ReturnsTrue()
        {
            // Arrange
            Notification notificação = new() 
            {
                UserId = "usuario1",
                Message = "Olá"
            };

            List<Notification> notifications = new() { notificação, notificação };

            _mockMessageService.SendMessage(Arg.Any<string>(), Arg.Any<string>()).Returns(true);

            // Act
            bool result = _service.NotifyUsers(notifications);

            // Assert
            Assert.True(result);
            _mockMessageService.Received(notifications.Count).SendMessage(Arg.Any<string>(), Arg.Any<string>());
        }

        [Fact]
        public void NotifyUsers_MessageSendingFails_ReturnsFalse()
        {
            // Arrange
            Notification notificação = new()
            {
                UserId = "usuario1",
                Message = "Olá!"
            };

            List<Notification> notifications = new() { notificação, notificação };

            _mockMessageService.SendMessage(Arg.Any<string>(), Arg.Any<string>()).Returns(false);

            // Act
            bool result = _service.NotifyUsers(notifications);

            // Assert
            Assert.False(result);
            _mockMessageService.Received(1).SendMessage(Arg.Any<string>(), Arg.Any<string>());
        }

    }
}
