using Calculator.Logic;
using Calculator.Logic.Exceptions;

using NUnit.Framework;

using System.Collections;

namespace Calculator.Test
{
    public class ParserTestFactory
    {
        public static IEnumerable SingleCases
        {
            get
            {
                yield return new TestCaseData("123r").Returns(new Currency[] { new Rub(123) });
                yield return new TestCaseData("123eur").Returns(new Currency[] { new Euro(123) });
                yield return new TestCaseData("$123").Returns(new Currency[] { new Dollar(123) });
                yield return new TestCaseData("-$123").Returns(new Currency[] { new Dollar(-123) });
                yield return new TestCaseData("$12,3").Returns(new Currency[] { new Dollar(12.3) });
            }
        }

        public static IEnumerable SequenceCases
        {
            get
            {
                yield return new TestCaseData("123r + 123eur").Returns(new Currency[] {
                    new Rub(123),
                    new Euro(123),
                }
                );
                yield return new TestCaseData("123eur - 321r").Returns(new Currency[] {
                    new Euro(123),
                    new Rub(-321),
                });
                yield return new TestCaseData("$123 - $123").Returns(new Currency[] {
                    new Dollar(123),
                    new Dollar(-123),
                });
                yield return new TestCaseData("$12,3+$12,3+$12,3 -$12,3 + $12,3").Returns(new Currency[] {
                    new Dollar(12.3),
                    new Dollar(12.3),
                    new Dollar(12.3),
                    new Dollar(-12.3),
                    new Dollar(12.3),
                });
                yield return new TestCaseData("-$123 - $123 +$123").Returns(new Currency[] {
                    new Dollar(-123),
                    new Dollar(-123),
                    new Dollar(123),
                });
            }
        }

        public static IEnumerable ExceptionCase
        {
            get
            {
                yield return new TestCaseData("123 eur - 321r", typeof(QueryException));
                yield return new TestCaseData("123eor - 321r", typeof(CurrencyFormatException));
                yield return new TestCaseData("$123:ToRub:ToDollar - $123", typeof(QuerySingleConverterException));
                yield return new TestCaseData("$12,3:Toeuro +$12,3+$12,3 -$12,3 + $12,3", typeof(ConverterNotExistException));
                yield return new TestCaseData("-$12.3 - $123 +$123", typeof(CurrencyFormatException));
            }
        }
    }
}