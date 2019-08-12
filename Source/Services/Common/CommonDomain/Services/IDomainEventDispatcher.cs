using CommonDomain.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CommonDomain.Services
{
    public interface IDomainEventDispatcher 
    {
        Task Dispatch(DomainEvent domainEvent, CancellationToken cancelationToken);
    }
}
