using CommonDomain.Model;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CommonInfrastructure
{
    public interface IRepository<T, TId> where T : AggregateRoot<TId> where TId : struct , IEquatable<TId>
    {
        Task<T> GetById(TId id);

        Task Save(T aggregateRoor, CancellationToken cancellationToken); 
    }
}
