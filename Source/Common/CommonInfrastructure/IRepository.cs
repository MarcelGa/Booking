using CommonDomain.Model;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CommonInfrastructure
{
    public interface IRepository<T, TId> 
        where T : AggregateRoot<TId> 
        where TId : struct , IEquatable<TId>
    {
        Task<T> GetById(TId id, bool trackChanges = true, CancellationToken cancellationToken = default);

        Task Save(CancellationToken cancellationToken = default); 
    }
}
