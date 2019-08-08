using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CommonDomain.CQRS
{
    public interface ICommandHandler<in TCommand> 
        where TCommand : ICommand
    {
        Task<Result> Handle(TCommand command);
    }
}
