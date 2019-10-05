using CommonDomain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppoitmentScheduling.Domain.Schedules
{
    internal class Store : Entity<Guid>
    {
        public string Name { get; }
        public IEnumerable<Procedure> AvaliableProcedures { get; }

        public IEnumerable<Staff> AvailableStaffs { get; }
    }
}
