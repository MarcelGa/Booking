using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CommonDomain.Model
{
    public interface IDomainEventHandler<T> : INotificationHandler<T> where T : DomainEvent
    {
    }
}
