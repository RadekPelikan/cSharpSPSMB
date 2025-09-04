using System;
using System.Globalization;

namespace setup
{
    public static class Calculator
    {
        public static string Calculate(string input)
        {
            string firstNumberText, secondNumberText, operatorText;
            double firstNumberParsed = 0;
            double secondNumberParsed = 0;
            double answer = 0;

            string[] split = input.Split(' ');
            
            firstNumberText = split[0];
            operatorText = split[1];
            secondNumberText = split[2];
            
            bool isFirstNumberParsable = double.TryParse(firstNumberText, NumberStyles.AllowDecimalPoint, CultureInfo.GetCultureInfo("en-Us"), out firstNumberParsed);
            bool isSecondNumberParsable = double.TryParse(secondNumberText, NumberStyles.AllowDecimalPoint, CultureInfo.GetCultureInfo("en-Us"), out secondNumberParsed);

            if (!isFirstNumberParsable)
            {
                Console.WriteLine("prvni cislo bad");
                return "";
            }
            
            if (!isSecondNumberParsable)
            {
                Console.WriteLine("druhy cislo bad");
                return "";
            }
            
            switch (operatorText)
            {
                case "+": 
                    answer = Add(firstNumberParsed,secondNumberParsed);
                    break;
                case "-":
                    answer = Subtract(firstNumberParsed, secondNumberParsed);
                    break;
                case "/": 
                    answer = Divide(firstNumberParsed, secondNumberParsed);
                    break;
                case "*":
                    answer = Multiply(firstNumberParsed, secondNumberParsed);
                    break;
                case "**":
                    answer = Power(firstNumberParsed, secondNumberParsed);
                    break;
                default:
                    Console.WriteLine("Unknown operator");
                    return "";
            } 
            
            
            return input + " = " + answer;
        }

        public static double Add(double x, double y)
        {
            return x + y;
        }

        public static double Subtract(double x, double y)
        {
            return x - y;
        }

        public static double Multiply(double x, double y)
        {
            return x * y;
        }

        public static double Divide(double x, double y)
        {
            return x / y;
        }

        public static double Power(double x, double y)
        {
            return Math.Pow(x, y);
        }
    }
}