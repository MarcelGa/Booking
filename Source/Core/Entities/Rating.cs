using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;

namespace Core.Entities
{
    public class Rating : BaseEntity
    {
        public Customer From { get; set; }

        public int Value { get; set; }

        public string Comment { get; set; }

        public DateTime Date { get; set; }
    }
}
