using System;
using System.Collections.Generic;
using System.Text;

namespace CommonDomain.Model
{
    public abstract class AggregateRoot<TId> : Entity<TId> where TId : struct , IEquatable<TId>
    {
        private List<DomainEvent> _domainEvents;
        public IReadOnlyList<DomainEvent> DomainEvents => _domainEvents;

        public void AddEvent(DomainEvent domainEvent)
        {
            _domainEvents = _domainEvents ?? new List<DomainEvent>();
            _domainEvents.Add(domainEvent);
        }

        public void ClearEvents()
        {
            _domainEvents?.Clear();
        }
    }
}
