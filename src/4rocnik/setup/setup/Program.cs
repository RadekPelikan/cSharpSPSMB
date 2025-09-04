using System;

namespace setup
{
    internal class Program
    {
        /*public static void Main(string[] args)
        {
            
            for (int i = 0; i < 100; i++)
            {
                if (i % 3 == 0 && i % 5 == 0)
                {
                    Console.WriteLine("fizzbuzz");
                }
                else if  (i % 5 == 0)
                {
                    Console.WriteLine("buzz");
                }else if (i % 3 == 0)
                {
                    Console.WriteLine("fizz");
                }
                else
                {
                    Console.WriteLine(i);
                }
                
            }
        }*/
        //hledání cisla
        public static void Main(string[] args)
        {
            int max;
            int min;
            int pokusy;
            bool jo = true;
            Console.WriteLine("zadej spodní hranici");
            min = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("zadej horní hranici");
            max = Convert.ToInt32(Console.ReadLine());
            while (jo == true)
            {
                Console.WriteLine("napis cislo");
                int number = Convert.ToInt32(Console.ReadLine());
                if (number > max)
                {
                    pokusy++;
                    Console.WriteLine("hledane cislo je mensi");
                }
                else if (number < min)
                {
                    Console.WriteLine("hledane cislo je vetsi");
                }
                else
                {
                    Console.WriteLine("vyhral si");
                    jo = false;
                }
            }

            



        }

    }
}