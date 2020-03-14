using Calculator.Logic.Exceptions;

using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Calculator.Logic
{
    public class Parser
    {
        public IEnumerable<Currency> Parse(string queryString)
        {
            QueryValidate(queryString);

            List<Currency> totalCurrencys = new List<Currency>();
            string token = string.Empty;
            queryString = queryString.Replace(" ", string.Empty);
            if (queryString.StartsWith('-'))
            {
                queryString = queryString.Substring(1);
                token = "-";
            }

            foreach (var item in queryString)
            {
                switch (item)
                {
                    case '+':
                        totalCurrencys.Add(TokenToCurrency(token.Trim()));
                        token = string.Empty;
                        break;

                    case '-':
                        totalCurrencys.Add(TokenToCurrency(token.Trim()));
                        token = "-";
                        break;

                    default:
                        token += item;
                        break;
                }
            }

            totalCurrencys.Add(TokenToCurrency(token.Trim()));

            return totalCurrencys;
        }

        private static void QueryValidate(string queryString)
        {
            Regex regex = new Regex(@"[^-\+\s]+\s+\w+");
            if (regex.IsMatch(queryString))
            {
                throw new QueryException();
            }
        }

        private Currency TokenToCurrency(string token)
        {
            var tokens = token.Split(':');

            if (tokens.Length > 2)
            {
                throw new QuerySingleConverterException();
            }

            Currency currency = CreateCurrency(tokens[0]);

            if (tokens.Length == 2)
            {
                switch (tokens[1])
                {
                    case "ToRub":
                        currency = currency.ToRub();
                        break;

                    case "ToDollar":
                        currency = currency.ToDollar();
                        break;

                    case "ToEuro":
                        currency = currency.ToEuro();
                        break;

                    default:
                        throw new ConverterNotExistException(tokens[1]);
                }
            }

            return currency;
        }

        private Currency CreateCurrency(string token)
        {
            if (token.StartsWith("-$") || token.StartsWith('$'))
            {
                return double.TryParse(token.Replace("$", string.Empty), out double result) ?
                    new Dollar(result) : throw new CurrencyFormatException(token);
            }

            string value = string.Concat(token.TakeWhile(c => !char.IsLetter(c)));

            token = token.Substring(value.Length);

            switch (token)
            {
                case "eur":
                    return double.TryParse(value, out double eurResult) ?
                        new Euro(eurResult) : throw new CurrencyFormatException(value + token);

                case "r":
                    return double.TryParse(value, out double rubResult) ?
                        new Rub(rubResult) : throw new CurrencyFormatException(value + token);

                default:
                    throw new CurrencyFormatException(token);
            }
        }
    }
}