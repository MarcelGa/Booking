using System;
using System.Threading.Tasks;
using Core.Interfaces.Messaging;
using Microsoft.Extensions.Logging;

namespace Services
{
    public class NullMessageSender : INotificationSender, ISmsSender, IEmailSender
    {
        private readonly ILogger<NullMessageSender> _logger;

        public NullMessageSender(ILogger<NullMessageSender> logger)
        {
            _logger = logger;
        }

        public Task SendNotificationAsyns(string message)
        {
            _logger.LogInformation($"Sending notification {message}");
            return Task.CompletedTask;
        }

        public Task SendSmsAsync(string number, string message)
        {
            _logger.LogInformation($"Sending sms to number {number} with message {message}");
            return Task.CompletedTask;
        }

        public Task SendEmailAsync(string address, string subject, string message)
        {
            _logger.LogInformation($"Sending email to adrress {address} with subject {subject} and message {message}");
            return Task.CompletedTask;
        }
    }
}
