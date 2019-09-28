using CommonDomain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReviewsManagement.Domain
{
    public class Customer : Entity<Guid>
    {
        public string Name { get; private set; }
    }
}
