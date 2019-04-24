using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;

namespace Core.Entities
{
    public class Vendor:BaseEntity
    {
        public string Name { get; set; }

        public string About { get; set; }

        public InstagramAccount Instagram { get; set; }

        public ICollection<ServicePlan> ServicesPlan { get; set; }

        public ICollection<Rating> Ratings { get; set; }
    }
}
