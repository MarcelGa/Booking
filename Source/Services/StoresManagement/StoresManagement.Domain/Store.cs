using CommonDomain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoresManagement.Domain
{

    public class Store : Entity<Guid>
    {
        public string Name { get; private set; }
        public string Info { get; private set; }
        public Adress Adress { get; private set; }
    }
}
