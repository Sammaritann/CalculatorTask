using Calculator.Logic.Exceptions;

using NUnit.Framework;

using System.Collections;

namespace Calculator.Test.CalculatorTest
{
    public class CalculatorTestFactory
    {
        public static IEnumerable SequenceCases
        {
            get
            {
                yield return new TestCaseData("123r + 123eur,ToDollar:").Returns("$248,46");
                yield return new TestCaseData("123eur - 321r,ToRub:").Returns("11979r");
            }
        }

        public static IEnumerable ExceptionCase
        {
            get
            {
                yield return new TestCaseData("123 eur - 321r,ToDollar:", typeof(QueryException));
                yield return new TestCaseData("123eor - 321r,ToDollar:", typeof(CurrencyFormatException));
                yield return new TestCaseData("$123:ToRub:ToDollar - $123,ToDollar:", typeof(QuerySingleConverterException));
                yield return new TestCaseData("$12,3:Toeuro +$12,3+$12,3 -$12,3 + $12,3,ToDollar:", typeof(ConverterNotExistException));
                yield return new TestCaseData("-$12.3 - $123 +$123,ToDollar:", typeof(CurrencyFormatException));
                yield return new TestCaseData("-$123 - $123 +$123,Todolar:", typeof(ConverterNotExistException));
            }
        }
    }
}