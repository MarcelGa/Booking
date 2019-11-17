using CommonDomain.Model;
using CommonDomain.ValueObjects;
using System;
using System.Collections.Generic;

namespace AppoitmentScheduling.Domain.Schedules
{
    internal class Staff : Entity<Guid> , IUser
    {
        public string Name { get; protected set; }
        public string Info { get; private set; }
        public IReadOnlyList<Procedure> Procedures { get; private set; }
        public IReadOnlyList<DateTimeRange> AvailableTimeSlots { get; private set; }
    }
}
