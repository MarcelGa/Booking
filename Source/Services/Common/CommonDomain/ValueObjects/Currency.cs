using CommonDomain.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace CommonDomain.ValueObjects
{
    public class Currency : ValueObject<Currency>
    {
        private readonly CultureInfo _culture;

        public string Symbol { get; }
        public string ISOSymbol { get; }

        public Currency(CultureInfo culture)
        {
            _culture = culture;

            RegionInfo region = new RegionInfo(culture.LCID);
            Symbol = region.CurrencySymbol;
            ISOSymbol = region.ISOCurrencySymbol;
        }
        
        public string Format(decimal value)
        {
            return value.ToString("C", _culture);
        }
    }
    public static class CurrencyCodeMapper
    {
        private static readonly Dictionary<string, Currency> CurrencysByISOSymbol;

        public static Currency GetCurrency(string code) { return CurrencysByISOSymbol[code.ToUpper()]; }
        public static IEnumerable<string> ISOSymbols = CurrencysByISOSymbol.Keys.AsEnumerable();

        static CurrencyCodeMapper()
        {
            CurrencysByISOSymbol = new Dictionary<string, Currency>();

            foreach(var culture in CultureInfo.GetCultures(CultureTypes.SpecificCultures))
            {
                RegionInfo region = new RegionInfo(culture.LCID);
                
                if (!CurrencysByISOSymbol.ContainsKey(region.ISOCurrencySymbol))
                    CurrencysByISOSymbol.Add(region.ISOCurrencySymbol.ToUpper(), new Currency(culture));
            }
        }
    }
}
