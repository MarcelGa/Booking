using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public class Store : BaseEntity
    {
        public string Name { get; set; }

        public GeoLocation Location { get; set; }
    }
}
