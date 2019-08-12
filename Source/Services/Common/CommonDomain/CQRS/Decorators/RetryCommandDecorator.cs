using CommonDomain.CQRS;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CommonDomain.Decorators.CQRS
{
    /// <summary>
    /// Decorator of command handler which repeat handle of command if result is not successful.
    /// </summary>
    /// <typeparam name="TCommand"></typeparam>
    public sealed class RetryCommandDecorator<TCommand> : ICommandHandler<TCommand>
        where TCommand : ICommand
    {
        private readonly ICommandHandler<TCommand> _handler;
        private readonly int RepeatCount = 3;

        public RetryCommandDecorator(ICommandHandler<TCommand> handler)
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
                catch(Exception ex)
                {
                    if (i >= RepeatCount)
                        return Result.Fail(ex);
                }
            }

        }
    }


    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = true)]
    public sealed class RetryCommandAttrribute : Attribute
    {
        public RetryCommandAttrribute()
        {
        }
    }
}
