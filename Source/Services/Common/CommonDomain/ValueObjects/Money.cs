using CommonDomain.Enums;
using CommonDomain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommonDomain.ValueObjects
{
    public class Money : ValueObject<Money>
    {
        public decimal Amount { get; private set; }

        public CurrencySymbol Currency { get; private set; }

        public Money(decimal amount, CurrencySymbol currency)
        {
            Amount = amount;
            Currency = currency;
        }
    }
}
