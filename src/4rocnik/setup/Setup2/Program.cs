using System;

namespace setup
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Random rnd = new Random();
            int vysledek = rnd.Next(0, 101);
            int guess = -1;

            while (guess != vysledek)
            {
                Console.WriteLine("Uhodni číslo (1-101) : ");
                guess = int.Parse(Console.ReadLine());
                
                if (vysledek == guess)
                    Console.WriteLine("Uhodl jsi to! Správné číslo bylo:" + vysledek);
                else if (guess > vysledek)
                    Console.WriteLine("Číslo je větší, než číslo které se snažíś uhodnout... číslo které jsi se snažil uhodnout je: " + guess);
                else if (vysledek > guess)
                    Console.WriteLine("Číslo je menší, než číslo které se snažíś uhodnout...číslo které jsi se snažil uhodnout je: " + guess);
                else
                    Console.WriteLine("?");
            } 
        }
    }
}