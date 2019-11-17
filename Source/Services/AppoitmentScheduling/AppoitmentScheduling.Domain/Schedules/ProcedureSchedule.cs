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

        public void CreateOrder(Procedure procedure, DateTime startDate, Client client, Staff staff)
        {
            if (!Store.AvaliableProcedures.Contains(procedure))
            {
                throw new InvalidOperationException($"Procedure order can't be created. Store { Store.Name} not support procedure {procedure.Name}");
            }

            if(!Store.AvailableStaffs.Any(_ => _.Staff.Equals(staff)))
            {
                throw new InvalidOperationException($"Procedure order can't be created. Staff {staff.Name} is not available in store { Store.Name}");
            }

            if (!staff.Procedures.Contains(procedure))
            {
                throw new InvalidOperationException($"Procedure order can't be created. Staff {staff.Name} not support procedure {procedure.Name}");
            }

            var order = new Order(procedure, client, startDate, staff);

            _orders.Add(order);

            //this.AddEvent
        }

        /// <summary>
        /// Method for decline order by staff which have access to this operation
        /// </summary>
        /// <param name="order"></param>
        /// <param name="by"></param>
        public void DeclineOrder(Order order, Staff by)
        {
            if(!Store.AvailableStaffs.Any(_ => _.Staff.Equals(by)))
            {
                throw new InvalidOperationException($"Order can't be declined by staff {by.Name} which is not available in store {Store.Name}");
            }

            var storeStaff = Store.AvailableStaffs.Single(_ => _.Staff.Equals(by));
            
            if(!storeStaff.Staff.Equals(order.Staff) && storeStaff.Role == StoreRole.Servant)
            {
                throw new InvalidOperationException($"Order can't ne declined by staff {by.Name} which have not enough permission for this operation");
            }

            order.Decline(storeStaff.Staff);
        }

        /// <summary>
        /// Method for decline order by client who creates it
        /// </summary>
        /// <param name="order"></param>
        /// <param name="by"></param>
        public void DeclineOrder(Order order, Client by)
        {
            if(!order.Client.Equals(by))
            {
                throw new ArgumentException("Other client like that who creates order can't decline it.", nameof(by));
            }

            order.Decline(by);
        }
    }
}
