using Calculator.Logic;

using NUnit.Framework;

using System;

namespace Calculator.Test.CalculatorTest
{
    public class CalculatorTest
    {
        [TestCaseSource(typeof(CalculatorTestFactory), "SequenceCases")]
        public string Calculate_Sequence_Number(string currency)
        {
            ICalculatorConverter calculator = new LogCalculatorConverter(new CalculatorConverter());
            return calculator.Calculate(currency);
        }

        [TestCaseSource(typeof(CalculatorTestFactory), "ExceptionCase")]
        public void Parse_Exception_Test(string currency, Type exceptionType)
        {
            ICalculatorConverter calculator = new LogCalculatorConverter(new CalculatorConverter());
            Assert.Throws(exceptionType, () => calculator.Calculate(currency));
        }
    }
}