using System;

namespace Setup3
{
    internal class Program
    {
        public static void Main(string[] args)
        {
             double firstNumber = double.Parse(Console.ReadLine());
             double secondNumber = double.Parse(Console.ReadLine());
             String op = Console.ReadLine();
             double vysledek = 0;
             
             switch (op)
             {
                 case "+":
                     vysledek = firstNumber + secondNumber;
                     Console.WriteLine(firstNumber + " + " + secondNumber + " = " + vysledek);
                     break;
                 case "-":
                     vysledek = firstNumber - secondNumber;
                     Console.WriteLine(firstNumber + " - " + secondNumber + " = " + vysledek);
                     break;
                 case "/":
                     vysledek = firstNumber / secondNumber;
                     Console.WriteLine(firstNumber + " / " + secondNumber + " = " + vysledek);

                     break;
                 case "*":
                     vysledek = firstNumber * secondNumber;
                     Console.WriteLine(firstNumber + " * " + secondNumber + " = " + vysledek);
                     break;
                 case "**":
                     vysledek = Math.Pow(firstNumber, secondNumber);
                     Console.WriteLine(firstNumber + " ** " + secondNumber + " = " + vysledek);
                     break;
                 default:
                     Console.WriteLine("Neznámý operátor!");
                     return;
             }
        }
    }
}