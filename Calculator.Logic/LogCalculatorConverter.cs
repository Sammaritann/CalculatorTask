using NLog;

using System;
using System.Text;

namespace Calculator.Logic
{
    public class LogCalculatorConverter : ICalculatorConverter
    {
        private readonly ICalculatorConverter calculatorConverter;

        private readonly Logger logger;

        public LogCalculatorConverter(ICalculatorConverter calculatorConverter)
        {
            this.calculatorConverter = calculatorConverter;
            this.logger = LogManager.GetCurrentClassLogger();
        }

        public string Calculate(string queryString)
        {
            string result = string.Empty;
            StringBuilder str = new StringBuilder();
            str.Append("Query: ")
                .Append(queryString)
                .Append(" | ");
            try
            {
                result = calculatorConverter.Calculate(queryString);
                str.Append("Result: ")
                    .Append(result);
                logger.Trace(str);
                return result;
            }
            catch (Exception e)
            {
                str.Append("Exception: ")
                    .Append(e.Message);

                logger.Error(str);

                throw;
            }
        }
    }
}