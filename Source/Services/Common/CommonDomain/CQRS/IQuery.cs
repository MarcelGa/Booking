using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace CommonDomain.CQRS
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TResult">Type of output parameter</typeparam>
    public interface IQuery<TResult> : IRequest<Result<TResult>>
    {
    }
}
