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

        public Store Store { get; }

        public DateTimeRange DateRange { get; }
        
        public IEnumerable<Order> Orders => _orders;

        public void AddNewOrder(Procedure procedure, DateTime startDate, Client client, Staff staff)
        {
            if (!Store.AvaliableProcedures.Contains(procedure))
            {
                throw new InvalidOperationException($"Procedure order can't be created. Store { Store.Name} not support procedure {procedure.Name}");
            }

            if(!Store.AvailableStaffs.Contains(staff))
            {
                throw new InvalidOperationException($"Procedure order can't be created. Staff {staff.Name} is not available in store { Store.Name}");
            }

            if (!staff.Procedures.Contains(procedure))
            {
                throw new InvalidOperationException($"Procedure order can't be created. Staff {staff.Name} not support procedure {procedure.Name}");
            }

            var order = new Order(procedure, client, startDate, DateTime.Now, staff);

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
