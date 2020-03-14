using Microsoft.Extensions.Configuration;

using System;

namespace Calculator.Logic
{
    public abstract class Currency
    {
        protected static IConfiguration configuration;

        protected double value;

        static Currency()
        {
            configuration = new ConfigurationBuilder()
                .AddJsonFile("exchangeRates.json")
                .Build();
        }

        public Currency()
        {
            this.value = 0d;
        }

        public Currency(double value)
        {
            this.value = value;
        }

        public abstract Dollar ToDollar();

        public abstract Rub ToRub();

        public abstract Euro ToEuro();

        public abstract override string ToString();

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            if (Object.ReferenceEquals(this, obj))
            {
                return true;
            }

            if (value != ((Currency)obj).value)
            {
                return false;
            }
            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}