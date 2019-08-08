using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CommonDomain.CQRS.Decorators
{
    public class AuditLoggingDecorator<TCommand> : ICommandHandler<TCommand>
        where TCommand : ICommand
    {
        private readonly ICommandHandler<TCommand> _handler;
        private readonly ILogger _logger;

        public AuditLoggingDecorator(ICommandHandler<TCommand> handler, ILogger logger)
        {
            _handler = handler;
            _logger = logger;
        }

        public async Task<Result> Handle(TCommand command)
        {
            string commandJson = JsonConvert.SerializeObject(command);
            string commandText = $"Command of type: {command.GetType().Name }: {commandJson}";

            Result result = await _handler.Handle(command);

            if (result.IsSuccessful)
                _logger.LogInformation(commandText);
            else
                _logger.LogError(commandText);

            return result;
        }
    }
}
