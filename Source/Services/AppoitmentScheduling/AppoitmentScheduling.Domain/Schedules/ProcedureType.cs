using CommonDomain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppoitmentScheduling.Domain.Schedules
{
    public class ProcedureType : Entity<int>
    {
        public int ProcedureCategoryId { get; protected set; }
    }
}
