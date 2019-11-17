using CommonDomain.Model;
using System;

namespace AppoitmentScheduling.Domain.Schedules
{
    internal class OrderStatusHistoryItem : ValueObject<OrderStatusHistoryItem>
    {
        public DateTime ChangedAt { get; }
        public IUser ChangedBy { get; }
        public OrderStatus Status { get; }

        public OrderStatusHistoryItem(OrderStatus status, IUser changedBy)
        {
            Status = status;
            ChangedBy = changedBy;
            ChangedAt = DateTime.Now;
        }
    }
}