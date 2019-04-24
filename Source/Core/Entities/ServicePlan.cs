using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public class ServicePlan : BaseEntity
    {
        public Service Service { get; set; }

        public Store Store { get; set; }

        public ICollection<ServiceUnit> TimeTable { get; set; }
    }
}
