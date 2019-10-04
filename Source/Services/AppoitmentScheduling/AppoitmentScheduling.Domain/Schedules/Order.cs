using CommonDomain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppoitmentScheduling.Domain.Schedules
{
    public class Order : Entity<int>
    {
        public Procedure Procedure { get; }

        public Client Client { get; }
    }

    public class Client : Entity<Guid>
    {
        public string Name { get; }
    }
}
