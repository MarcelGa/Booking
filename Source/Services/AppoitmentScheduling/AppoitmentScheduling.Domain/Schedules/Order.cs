using CommonDomain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppoitmentScheduling.Domain.Schedules
{
    internal class Order : Entity<int>
    {
        public Procedure Procedure { get; }
        public Client Client { get; }
        public DateTime StartAt { get; }
        public Staff Staff { get; }
        public OrderStatus Status => orderStatusHistory.Last().Status; 

        public Order(Procedure procedure, Client client, DateTime startAt, Staff staff)
        {
            Procedure = procedure;
            Client = client;
            StartAt = startAt;
            Staff = staff;

            orderStatusHistory = new List<OrderStatusHistoryItem>();
            UpdateStatus(OrderStatus.Created, client);
        }

        private List<OrderStatusHistoryItem> orderStatusHistory { get; set; }
        public IEnumerable<OrderStatusHistoryItem> OrderStatusHistory => orderStatusHistory;

        public void Decline(IUser by)
        {
            if(Status == OrderStatus.Declined)
            {
                throw new InvalidOperationException("Cannot decline already declined order.");
            }
            
            UpdateStatus(OrderStatus.Declined, by);
        }

        public void Accept(IUser by)
        {
            if (Status == OrderStatus.Acceppted)
            {
                throw new InvalidOperationException("Cannot accept already accepted order.");
            }

            UpdateStatus(OrderStatus.Acceppted, by);
        }
        
        private void UpdateStatus(OrderStatus status, IUser by)
        {
            orderStatusHistory.Add(new OrderStatusHistoryItem(status, by));
        }
    }
}
