using CommonDomain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppoitmentScheduling.Domain.Schedules
{
    internal class Order : Entity<int>
    {
        public Procedure Procedure { get; }

        public Client Client { get; }
    }

    internal class Client : Entity<Guid>
    {
        public string Name { get; }
    }
}
