using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace CommonDomain.CQRS
{
    /// <summary>
    /// Handler of guery request which retrieve result
    /// </summary>
    /// <typeparam name="TQuery">query type</typeparam>
    /// <typeparam name="TResult">result type</typeparam>
    public interface IQueryHandler<TQuery, TResult> : IRequestHandler<TQuery, Result<TResult>>
        where TQuery : IQuery<TResult>
    {
    }
}
