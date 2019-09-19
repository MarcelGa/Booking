using CommonDomain.Model;
using System;
using System.Collections.Generic;

namespace AppoitmentScheduling.Domain.Schedules
{
    public class Staff : Entity<Guid>
    {
        public IReadOnlyList<Procedure> Procedures { get; private set; }

        public IReadOnlyList<DateTimeRange> AvailableTimeSlots { get; private set; }
    }




}
