using Calculator.Logic.Exceptions;

namespace Calculator.Logic
{
    public class Dollar : Currency
    {
        private static double euroCoef;
        private static double rubCoef;

        static Dollar()
        {
            euroCoef = double.Parse(configuration.GetSection("Dollar rate")["ToEuro"]);
            rubCoef = double.Parse(configuration.GetSection("Dollar rate")["ToRub"]);
        }

        public Dollar() : base()
        {
        }

        public Dollar(double value) : base(value)
        {
        }

        public override Dollar ToDollar()
        {
            throw new ConvertException();
        }

        public override Euro ToEuro()
        {
            return new Euro(value * euroCoef);
        }

        public override Rub ToRub()
        {
            return new Rub(value * rubCoef);
        }

        public override string ToString()
        {
            return $"${value}";
        }

        public static Dollar operator +(Dollar leftOperand, Dollar rightOperand)
        {
            return new Dollar(leftOperand.value + rightOperand.value);
        }
    }
}