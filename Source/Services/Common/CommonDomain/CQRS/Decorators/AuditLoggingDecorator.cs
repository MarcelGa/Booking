using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CommonDomain.CQRS.Decorators
{
    /// <summary>
    /// Decorator of command handler which log command and exception if result is not successful
    /// </summary>
    /// <typeparam name="TCommand"></typeparam>
    public sealed class AuditLoggingDecorator<TCommand> : ICommandHandler<TCommand>
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
            Result result = await _handler.Handle(command);

            if (!result.IsSuccessful)
            {
                string commandJson = JsonConvert.SerializeObject(command);
                string commandText = $"Command of type: {command.GetType().Name }: {commandJson}";
                _logger.LogError(GetErrorLogMessage(commandText, result.Exception));
            }
            return result;
        }

        private static string GetErrorLogMessage(string message, Exception ex)
        {
            string exceptionJson = JsonConvert.SerializeObject(ex);
            return message + " | " + exceptionJson;
        }
    }

    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = true)]
    public sealed class AuditLoggingCommandAttrribute : Attribute
    {
        public AuditLoggingCommandAttrribute()
        {
        }
    }
}
