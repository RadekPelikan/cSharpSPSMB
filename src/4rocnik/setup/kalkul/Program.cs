using System;

namespace kalkul
{
    internal class Program
    {
        public static void Main(string[] args)
        {
           double a = Convert.ToDouble(Console.ReadLine());
           double b = Convert.ToDouble(Console.ReadLine());
           string oper = Console.ReadLine();

           
           double answer;

            switch (oper)
            
            {
                case "+":
                    answer = a + b;
                break;
                case "-":
                    answer = a - b;
                break;
                case "*":
                    answer = a * b;
                break;
                case "**":
                    answer = Math.Pow(a, b);
                    break;
                case "/":
                if (b != 0)
                    answer = a / b;
                else
                {
                    Console.WriteLine("Dělení nulou není povoleno!");
                    return;
                }
                break;
                default:
                Console.WriteLine("Neznámý operátor.");
                return;
            }
            
        }
    }
}