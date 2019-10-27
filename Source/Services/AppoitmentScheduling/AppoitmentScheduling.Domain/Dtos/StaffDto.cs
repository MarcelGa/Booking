using System;

namespace AppoitmentScheduling.Domain.Dtos
{
    public sealed class StaffDto
    {
        public Guid StaffId { get; }
        public string Staff { get; }
        public OrderDto[] Orders { get; }
    }
}
