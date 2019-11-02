using System;

namespace AppoitmentScheduling.Domain.Dtos
{    
    public sealed class OrderDto
    {
        public string Procedure { get; set; }
        public DateTime Start { get; set; }
        public int Duration { get; set; }
        public string Status { get; set; }
    }
}
