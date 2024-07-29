using System.Net.Mail;
using Interfaces;

namespace TaskTracker.Services.Implementations
{
    public class EmailMessageService : IMessageService
    {
        public void SendMessage(string message)
        {
            var client = new SmtpClient()
            {

            };

        }
    }
}
