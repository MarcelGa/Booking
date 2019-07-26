using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Messaging
{
    public interface ISmsSender
    {
        Task SendSmsAsync(string number, string message);
    }
}
