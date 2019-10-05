using CommonDomain.Model;
using CommonDomain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AppoitmentScheduling.Domain.Schedules
{
    internal class ProcedureSchedule : AggregateRoot<Guid>
    {
        private readonly List<Order> _orders = new List<Order>();

        public Guid StoreGuid { get; private set; }

        public DateTimeRange DateRange { get; private set; }
        
        public IEnumerable<Order> Orders => _orders;

        public void AddNewOrder(Procedure procedure, DateTime startDate, Client client, Staff staff)
        {

            var order = new Order();

            _orders.Add(order);

            //this.AddEvent
        }

        public void RemoveOrder(Order order)
        {
            if(!Orders.Any(_=> _.Id == order.Id))
            {
                throw new ArgumentException("Cannot remove not existing order from schedule.", nameof(order));
            }

            _orders.RemoveAll(_ => _.Id == order.Id);

            //this.AddEvent
        }

    }
}
