using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CommonDomain.CQRS
{
    public interface IQueryHandler<in TQuery, TResult> 
        where TQuery : IQuery<TResult>
    {
        Task<Result<TResult>> Handle(TQuery query);
    }
}
