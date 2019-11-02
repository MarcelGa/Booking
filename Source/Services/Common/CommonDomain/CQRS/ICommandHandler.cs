using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CommonDomain.CQRS
{
    /// <summary>
    /// Command handler with genreic type data parameter of result
    /// </summary>
    /// <typeparam name="TCommand"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    [Obsolete("Command should not return any data",false)]
    public interface ICommandHandler<in TCommand, TResult> : IRequestHandler<TCommand, Result<TResult>>
        where TCommand : ICommand<TResult>
    {
    }

    /// <summary>
    /// Command handler
    /// </summary>
    /// <typeparam name="TCommand"></typeparam>
    public interface ICommandHandler<in TCommand> : IRequestHandler<TCommand, Result> where TCommand : ICommand
    {
    }
}
