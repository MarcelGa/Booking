using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CommonDomain.CQRS
{
    public interface ICommandHandler<TCommand> where TCommand : ICommand
    {
        Task<Result> Handle(TCommand command);
    }

    public interface ICommandHandler<TCommand, TResult> 
        where TCommand : ICommand 
        where TResult : class
    {
        Task<Result<TResult>> Handle(TCommand command);
    }
}
