using CommonDomain.Model;
using System;

namespace AppoitmentScheduling.Domain.Schedules
{
    public class ProcedureSchedule : AggregateRoot<Guid>
    {
        public Store Store { get; private set; }
    }
}
