using Calculator.Logic;

using NUnit.Framework;

using System;
using System.Collections.Generic;
using System.Linq;

namespace Calculator.Test
{
    public class ParserTest
    {
        [TestCaseSource(typeof(ParserTestFactory), "SingleCases")]
        public IEnumerable<Currency> Parse_Single_Number(string currency)
        {
            Parser parser = new Parser();
            return parser.Parse(currency).ToArray();
        }

        [TestCaseSource(typeof(ParserTestFactory), "SequenceCases")]
        public IEnumerable<Currency> Parse_Sequence_Number(string currency)
        {
            Parser parser = new Parser();
            return parser.Parse(currency).ToArray();
        }

        [TestCaseSource(typeof(ParserTestFactory), "ExceptionCase")]
        public void Parse_Exception_Test(string currency, Type exceptionType)
        {
            Parser parser = new Parser();
            Assert.Throws(exceptionType, () => parser.Parse(currency));
        }
    }
}