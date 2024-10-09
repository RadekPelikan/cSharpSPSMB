using System;

namespace Library
{
    public class Calculator
    {
        protected static double MyNumber; 

        public static double Add(double a, double b)
        {
            return a + b;
        }

        internal static double Sub(double a, double b)
        {
            return a - b;
        }
    }

    public class Human : Calculator
    {
        public Human()
        {
            Console.WriteLine(MyNumber);
        }
    }
}