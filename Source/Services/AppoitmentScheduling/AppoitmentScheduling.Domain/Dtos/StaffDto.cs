using System;

namespace AppoitmentScheduling.Domain.Dtos
{
    public sealed class StaffDto
    {
        public Guid StaffId { get; set; }
        public string Staff { get; set; }
        public OrderDto[] Orders { get; set; }
    }
}
