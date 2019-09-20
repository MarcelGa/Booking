using CommonDomain.Enums;
using CommonDomain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommonDomain.ValueObjects
{
    public class Money : ValueObject<Money>
    {
        public static Money OneDollar => new Money(1, CurrencySymbol.Usd);
        public static Money OneEuro => new Money(1, CurrencySymbol.Eur);

        public decimal Amount { get; private set; }

        public CurrencySymbol Currency { get; private set; }

        public Money(decimal amount, CurrencySymbol currency = CurrencySymbol.Eur)
        {
            if(amount < 0)
            {
                throw new ArgumentOutOfRangeException("Money could't be less then zero");
            }

            Amount = amount;
            Currency = currency;
        }

        protected override bool EqualsCore(Money other)
        {
            return other.Amount == Amount && other.Currency == Currency;
        }
    }
}
