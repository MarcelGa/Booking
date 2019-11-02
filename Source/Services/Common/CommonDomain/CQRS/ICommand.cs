using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommonDomain.CQRS
{
    /// <summary>
    /// Command with generic type data parameter of result
    /// </summary>
    /// <typeparam name="TResult">type of data parameter returned in result</typeparam>
    public interface ICommand<TResult> : IRequest<Result<TResult>>
    {
    }
    
    /// <summary>
    /// Command
    /// </summary>
    public interface ICommand : IRequest<Result>
    {
    }
}
