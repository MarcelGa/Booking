using CommonDomain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommonDomain.ValueObjects
{
    public class Currency : ValueObject<Currency>
    {
        public string Symbol { get; private set; }
        public int DisplayDecimals { get; private set; }
    }
}
