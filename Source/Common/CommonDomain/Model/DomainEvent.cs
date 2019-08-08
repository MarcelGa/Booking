using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommonDomain.Model
{
    /// <summary>
    /// Notify other applications/domains about change state of domain
    /// </summary>
    public abstract class DomainEvent : INotification
    {
        public DateTime OccuredOn { get; } = DateTime.Now;
    }
}
