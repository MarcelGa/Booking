using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CommonDomain.CQRS
{
    public class RepeatCommandHandler<TCommand> : ICommandHandler<TCommand>
        where TCommand : ICommand
    {
        private readonly ICommandHandler<TCommand> _handler;
        private readonly int RepeatCount = 3;

        public RepeatCommandHandler(ICommandHandler<TCommand> handler)
        {
            _handler = handler;
        }

        public async Task<Result> Handle(TCommand command)
        {
            for (int i = 0; ; i++)
            {
                try
                {
                    Result result = await _handler.Handle(command);
                    return result;
                }
                catch
                {
                    if (i >= RepeatCount)
                        throw;
                }
            }

        }
    }
}
