using System;
using System.Collections.Generic;

namespace Calculator.Logic
{
    public class ConverterHelper
    {
        public static Currency AccamulateConvertingToRub(IEnumerable<Currency> totalCurrencys)
        {
            if (totalCurrencys is null)
            {
                throw new ArgumentNullException(nameof(totalCurrencys));
            }

            Rub rub = new Rub();
            foreach (var item in totalCurrencys)
            {
                rub += item is Rub rubItem ? rubItem : item.ToRub();
            }

            return rub;
        }

        public static Currency AccamulateConvertingToDollar(IEnumerable<Currency> totalCurrencys)
        {
            Dollar dollar = new Dollar();
            foreach (var item in totalCurrencys)
            {
                dollar += item is Dollar dollarItem ? dollarItem : item.ToDollar();
            }

            return dollar;
        }

        public static Currency AccamulateConvertingToEuro(IEnumerable<Currency> totalCurrencys)
        {
            Euro euro = new Euro();
            foreach (var item in totalCurrencys)
            {
                euro += item is Euro euroItem ? euroItem : item.ToEuro();
            }

            return euro;
        }
    }
}