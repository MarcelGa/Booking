using CommonDomain.Enums;
using CommonDomain.Model;
using System;

namespace CommonDomain.ValueObjects
{
    public class Money : ValueObject<Money>
    {
        public static Money OneDollar => new Money(1, "USD");
        public static Money OneEuro => new Money(1, "EUR");

        public decimal Amount { get; }
        public Currency Currency { get; }

        public Money(decimal amount, string CurrencySymbol = "EUR")
        {
            if(amount < 0)
            {
                throw new ArgumentOutOfRangeException("Money could't be less then zero");
            }

            Amount = amount;
            Currency = CurrencyCodeMapper.GetCurrency(CurrencySymbol);
        }

        public override string ToString()
        {
            return Currency.Format(Amount) + Currency.Symbol;
        }
    }
}
