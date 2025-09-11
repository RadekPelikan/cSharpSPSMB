using System;

namespace Setup2
{
    internal class Program
    {
        static void Main()
        {
            Random rnd = new Random();
            int number = rnd.Next(0, 100);
            Console.WriteLine("Your random number is: " + number);
            do
            {
                String guess = Console.ReadLine();
            }
        }
    }
}