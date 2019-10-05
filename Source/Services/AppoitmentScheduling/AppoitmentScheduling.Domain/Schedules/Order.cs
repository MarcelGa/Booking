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
        public DateTime StartAt { get; }
        public DateTime CretetAt { get; }
        public Staff Staff { get; }
        public Order(Procedure procedure, Client client, DateTime startAt, DateTime createdAt, Staff staff)
        {
            Procedure = procedure;
            Client = client;
            StartAt = startAt;
            CretetAt = createdAt;
            Staff = staff;
        }
    }
}
