using CommonDomain.Model;
using System;

namespace AppoitmentScheduling.Domain.Schedules
{
    public class ProcedureSchedule : AggregateRoot<Guid>
    {
        public Guid StoreGuid { get; private set; }
    }
}
