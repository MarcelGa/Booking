using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CommonDomain.CQRS
{
    /// <summary>
    /// Handler of guery request which retrieve result
    /// </summary>
    /// <typeparam name="TQuery"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    public interface IQueryHandler<in TQuery, TResult> 
        where TQuery : IQuery<TResult>
        where TResult : class
    {
        Task<Result<TResult>> Handle(TQuery query);
    }
}
