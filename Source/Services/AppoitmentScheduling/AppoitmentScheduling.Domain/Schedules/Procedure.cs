using CommonDomain.Model;
using CommonDomain.ValueObjects;
using System;

namespace AppoitmentScheduling.Domain.Schedules
{
    /// <summary>
    /// Procedure for schedule (e.g. man haircut with shower, ...) created by organisation admin or manager
    /// </summary>
    public class Procedure : Entity<Guid>
    {
        public string Name { get; private set; }

        public string Info { get; private set; }

        public ProcedureType ProcedureType { get; private set; }

        public Money Price { get; private set; }

        public DateTimeRange Duration { get; private set; }
    }
}
