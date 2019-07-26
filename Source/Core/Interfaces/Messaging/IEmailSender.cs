using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Messaging
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string address, string subject, string message);
    }
}
