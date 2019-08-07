using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CommonDomain.CQRS
{
    public interface IQueryHandler<TQuery, TResult> 
        where TQuery : IQery<TResult>
    {
        Task<TResult> Handle(TQuery query);
    }
}
