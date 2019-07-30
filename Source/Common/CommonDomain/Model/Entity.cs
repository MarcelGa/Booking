using System;
using System.Collections.Generic;

namespace CommonDomain.Model
{
    public abstract class Entity<TId> where TId : struct, IEquatable<TId>
    {
        public TId Id { get; protected set; }

        public override bool Equals(object obj)
        {
            var other = obj as Entity<TId>;

            if (other is null)
                return false;

            if (ReferenceEquals(this, other))
                return true;

            if (GetType() != other.GetType())
                return false;

            return EqualityComparer<TId>.Default.Equals(Id, other.Id);
        }

        public static bool operator ==(Entity<TId> a, Entity<TId> b)
        {
            if (a is null && b is null)
                return true;

            if (a is null || b is null)
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(Entity<TId> a, Entity<TId> b)
        {
            return !(a == b);
        }

        public override int GetHashCode()
        {
            return (GetType().ToString() + Id).GetHashCode();
        }
    }
}
