using Calculator.Logic.Exceptions;

using System.Collections.Generic;

namespace Calculator.Logic
{
    public class CalculatorConverter : ICalculatorConverter
    {
        public string Calculate(string queryString)
        {
            var subIndex = queryString.LastIndexOf(',');
            var convertString = queryString.Substring(subIndex+1);
            var query = queryString.Substring(0,subIndex);

            IEnumerable<Currency> currencies = new Parser().Parse(query);
            currencies = Accumulate(currencies);
            return Convert(convertString, currencies).ToString();
        }

        private Currency Convert(string converString, IEnumerable<Currency> currencies)
        {
            switch (converString.Trim())
            {
                case "ToDollar:":
                    return ConverterHelper.AccamulateConvertingToDollar(currencies);

                case "ToEuro:":
                    return ConverterHelper.AccamulateConvertingToEuro(currencies);

                case "ToRub:":
                    return ConverterHelper.AccamulateConvertingToRub(currencies);

                default:
                    throw new ConverterNotExistException(converString);
            }
        }

        private IEnumerable<Currency> Accumulate(IEnumerable<Currency> totalCurrencys)
        {
            Dollar dollars = new Dollar();
            Euro euros = new Euro();
            Rub rubs = new Rub();

            foreach (var item in totalCurrencys)
            {
                switch (item)
                {
                    case Dollar dollar:
                        dollars += dollar;
                        break;

                    case Euro euro:
                        euros += euro;
                        break;

                    case Rub rub:
                        rubs += rub;
                        break;
                }
            }

            return new Currency[] { dollars, euros, rubs };
        }
    }
}