using CommonDomain.Model;
using System;

namespace AppoitmentScheduling.Domain.Schedules
{
    internal class Client : Entity<Guid>
    {
        public string Name { get; }
    }
}
