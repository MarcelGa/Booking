using CommonDomain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppoitmentScheduling.Domain.Schedules
{
    /// <summary>
    /// Category of procedure (e.g. Hair, Nails, ...) created by app admin
    /// </summary>
    public class ProcedureCategory : Entity<int>
    {
        public string Name { get; protected set; }
    }
}
