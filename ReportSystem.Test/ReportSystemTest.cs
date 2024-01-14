using ReportSystem.Businesslayer;
using ReportSystem.Entities;
using ReportSystem.Exceptions;
using Xunit;

namespace ReportSystem.Test
{
    public class ReportSystemTest
    {
        [Fact]
        public void AuthenticationException()
        {
            var typeMessage = new TypeMessage("sms");
            var message1 = new Message(typeMessage, 1, "tariff problem");
            var message2 = new Message(typeMessage, 1, "speed internet problem");

            var messageList = new List<Message>();
            var messageAllowedList = new List<Message>();
            var workers = new List<Worker>();
            messageList.Add(message1);
            messageList.Add(message2);

            var worker = new Worker("John", "Operator", messageAllowedList, 123654);
            var serviceWorker = new WorkerService("John", "Operator", messageAllowedList, 123654, workers);
            Assert.Throws<InvalidAuthenticationfailedException>(() =>
            {
                serviceWorker.LogIn(worker, "Operator", 123655);
            });
        }

        [Fact]
        public void AuthorizationException()
        {
            var typeMessage = new TypeMessage("sms");
            var typeMessageList = new List<TypeMessage>();
            var message1 = new Message(typeMessage, 1, "tariff problem");
            var message2 = new Message(typeMessage, 1, "speed internet problem");

            var messageList = new List<Message>();
            var messageAllowedList = new List<Message>();
            var workers = new List<Worker>();
            messageList.Add(message1);
            messageList.Add(message2);

            var worker = new Worker("John", "User", messageAllowedList, 123654);
            var serviceMessage = new SystemMessageService(typeMessage, 1, "tariff prolem", typeMessageList, messageList);
            Assert.Throws<InvalidAuthorizationFailed>(() =>
            {
                serviceMessage.MessageChecked(worker, message1);
            });
        }

        [Fact]
        public void MessageNotCheckException()
        {
            var typeMessage = new TypeMessage("sms");
            var typeMessageList = new List<TypeMessage>();
            var message1 = new Message(typeMessage, 1, "tariff problem");
            var message2 = new Message(typeMessage, 1, "speed internet problem");

            var messageList = new List<Message>();
            var messageAllowedList = new List<Message>();
            var workers = new List<Worker>();
            messageList.Add(message1);
            messageList.Add(message2);

            var worker = new Worker("John", "Operator", messageAllowedList, 123654);
            var serviceMessage = new SystemMessageService(typeMessage, 1, "tariff prolem", typeMessageList, messageList);
            Assert.Throws<InvalidMessageNotCheck>(() =>
            {
                serviceMessage.MessageAllowed(worker, message1);
            });
        }
    }
}