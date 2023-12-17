using btg_testes_auto.Notification;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace btg_test.NotificationEmailTest
{
    public class NotificationServiceTest
    {
        private readonly IEmailService _mockEmailService;
        private readonly NotificationService _sut;

        public NotificationServiceTest()
        {
            _mockEmailService = Substitute.For<IEmailService>();
            _sut = new NotificationService(_mockEmailService);
        }

        [Fact]
        public void SendNotification_WithNonEmptyMessage_ShouldCallSendEmail()
        {
            // Arrange
            string recipient = "teste@gmail.com";
            string message = "Mensagem de teste";

            // Act
            _sut.SendNotification(recipient, message);

            // Assert
            _mockEmailService.Received(1).SendEmail(recipient, "Notification", message);
        }

        [Fact]
        public void SendNotification_WithEmptyMessage_ShouldNotCallSendEmail()
        {
            // Arrange
            string recipient = "teste@gmail.com";
            string emptyMessage = string.Empty;

            // Act
            _sut.SendNotification(recipient, emptyMessage);

            // Assert
            _mockEmailService.DidNotReceive().SendEmail(Arg.Any<string>(), Arg.Any<string>(), Arg.Any<string>());
        }

        [Fact]
        public void SendNotification_EmailServiceThrowsException_ShouldReturnFalse()
        {
            // Arrange
            string recipient = "teste@gmail.com";
            string message = "Mensagem de teste";
            _mockEmailService.SendEmail(Arg.Any<string>(), Arg.Any<string>(), Arg.Any<string>())
                .Throws(new System.Exception("Simulando uma exceção"));

            // Act
            bool result = _sut.SendNotification(recipient, message);

            // Assert
            Assert.False(result);
        }
    }
}
