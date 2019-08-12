using CommonDomain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppoitmentScheduling.Domain.Schedules
{
    public class ProcedureCategory : Entity<int>
    {
        public string Name { get; protected set; }
    }
}
