using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommonDomain.Model
{
    public abstract class DomainEvent : INotification
    {
        public DateTime OccuredOn { get; } = DateTime.Now;
    }
}
