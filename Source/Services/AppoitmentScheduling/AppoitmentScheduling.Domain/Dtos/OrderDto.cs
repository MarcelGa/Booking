using CommonDomain.ValueObjects;
using System;

namespace AppoitmentScheduling.Domain.Dtos
{    
    public sealed class OrderDto
    {
        public string Procedure { get; }
        public DateTime Start { get; }
        public int Duration { get; }
        public string Status { get; }
    }
}
