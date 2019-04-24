using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public interface IDbInitializer
    {
        Task Seed();
    }
}
