using CommonDomain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppoitmentScheduling.Domain.Schedules
{
    public class Store : Entity<Guid>
    {
        public string Name { get; }
        IEnumerable<Procedure> AvaliableProcedures { get; }
    }
}
