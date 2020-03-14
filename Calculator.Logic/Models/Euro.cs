using Calculator.Logic.Exceptions;

namespace Calculator.Logic
{
    public class Euro : Currency
    {
        private static double dollarCoef;
        private static double rubCoef;

        static Euro()
        {
            dollarCoef = double.Parse(configuration.GetSection("Euro rate")["ToDollar"]);
            rubCoef = double.Parse(configuration.GetSection("Euro rate")["ToRub"]);
        }

        public Euro() : base()
        {
        }

        public Euro(double value) : base(value)
        {
        }

        public override Dollar ToDollar()
        {
            return new Dollar(value * dollarCoef);
        }

        public override Euro ToEuro()
        {
            throw new ConvertException();
        }

        public override Rub ToRub()
        {
            return new Rub(value * rubCoef);
        }

        public override string ToString()
        {
            return $"{value}euro";
        }

        public static Euro operator +(Euro leftOperand, Euro rightOperand)
        {
            return new Euro(leftOperand.value + rightOperand.value);
        }
    }
}