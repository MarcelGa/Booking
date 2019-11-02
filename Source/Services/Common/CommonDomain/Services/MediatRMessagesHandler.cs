using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace CommonDomain.CQRS
{
    internal sealed class MediatRMessagesHandler : IMessages
    {
        public MediatRMessagesHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        private readonly IMediator _mediator;

        public Task Publish(object notification, CancellationToken cancellationToken = default)
        {
            return _mediator.Publish(notification, cancellationToken);
        }

        public Task Publish<TNotification>(TNotification notification, CancellationToken cancellationToken = default) where TNotification : INotification
        {
            return _mediator.Publish<TNotification>(notification, cancellationToken);
        }

        public Task<TResponse> Send<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken = default)
        {
            return _mediator.Send<TResponse>(request, cancellationToken);
        }
    }
}