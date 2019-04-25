using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Messaging
{
    public interface INotificationSender
    {
        Task SendNotificationAsyns(string message);
    }
}
