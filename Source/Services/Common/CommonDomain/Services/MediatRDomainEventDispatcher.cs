using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CommonDomain.Model;
using MediatR;

namespace CommonDomain.Services
{
    internal sealed class MediatRDomainEventDispatcher : IDomainEventDispatcher
    {
        private readonly IMediator _mediator;

        public MediatRDomainEventDispatcher(IMediator mediator)
        {
            _mediator = mediator;
        }

        public Task Dispatch(DomainEvent domainEvent, CancellationToken cancelationToken)
        {
            return _mediator.Publish(domainEvent, cancelationToken);
        }
    }
}
