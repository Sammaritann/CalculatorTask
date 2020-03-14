using Calculator.Logic.Exceptions;

namespace Calculator.Logic
{
    public class Rub : Currency
    {
        private static double dollarCoef;
        private static double euroCoef;

        static Rub()
        {
            dollarCoef = double.Parse(configuration.GetSection("Rub rate")["ToDollar"]);
            euroCoef = double.Parse(configuration.GetSection("Rub rate")["ToEuro"]);
        }

        public Rub() : base()
        {
        }

        public Rub(double value) : base(value)
        {
        }

        public override Dollar ToDollar()
        {
            return new Dollar(value * dollarCoef);
        }

        public override Euro ToEuro()
        {
            double coef = double.Parse(configuration.GetSection("Rub rate")["ToEuro"]);
            return new Euro(value * euroCoef);
        }

        public override Rub ToRub()
        {
            throw new ConvertException();
        }

        public override string ToString()
        {
            return $"{value}r";
        }

        public static Rub operator +(Rub leftOperand, Rub rightOperand)
        {
            return new Rub(leftOperand.value + rightOperand.value);
        }
    }
}