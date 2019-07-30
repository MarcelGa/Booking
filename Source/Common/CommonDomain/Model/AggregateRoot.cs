using System;
using System.Collections.Generic;
using System.Text;

namespace CommonDomain.Model
{
    public abstract class AggregateRoot<TId> : Entity<TId> where TId : struct , IEquatable<TId>
    {
    }
}
