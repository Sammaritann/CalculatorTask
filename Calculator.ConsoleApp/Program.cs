using Calculator.Logic;
using Calculator.Logic.Exceptions;

using System;

namespace Calculator.ConsoleApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            ICalculatorConverter calculator = new LogCalculatorConverter(new CalculatorConverter());

            while (true)
            {
                Console.Write("Enter the query: ");
                string queryString = Console.ReadLine();
                SaveExecute(() => Console.WriteLine("Result: " + calculator.Calculate(queryString)));
            }
        }

        private static void SaveExecute(Action action)
        {
            try
            {
                action.Invoke();
            }
            catch (QuerySingleConverterException e)
            {
                Console.WriteLine($"Error: Invalid single convert {e.Message}");
                Console.WriteLine("Currency can convert only once like: 1r:ToEuro");
            }
            catch (CurrencyFormatException e)
            {
                Console.WriteLine($"Error: Invalid currency {e.Message}");
                Console.WriteLine("Use only ($, eur, r)");
            }
            catch (ConverterNotExistException e)
            {
                Console.WriteLine($"Error: Invalid convert currency {e.Message}");
                Console.WriteLine("Use only (:ToDollar, :ToEuro, :ToRub)");
            }
            catch (QueryException)
            {
                Console.WriteLine("Error: Invalid request input.");
                Console.WriteLine("The request should be like: 1eur + 1r:ToEuro + $1,ToDollar:");
            }
            catch (ConvertException)
            {
                Console.WriteLine("Error: Invalid currency convert");
                Console.WriteLine("You can’t convert a currency to yourself");
            }
        }
    }
}