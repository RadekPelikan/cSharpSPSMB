using System;

namespace setup
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            int max, min,pokus = 0;
            bool isrunning = true;
            
            Console.WriteLine("min");
            max = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("max");
            min = Convert.ToInt32(Console.ReadLine());
            
            Random rnd = new Random();
            int num = rnd.Next(min, max+1);
            while (isrunning)
            {
                Console.WriteLine("vyhral si");
                int number = Convert.ToInt32(Console.ReadLine());
                if (number <num)
                {
                    ++pokus;
                    Console.WriteLine("hledane cislo je mensi");
                }
                else if (number < num)
                {
                    ++pokus;
                    Console.WriteLine("hledane cislo je vetsi");
                } 
                else
                {
                    Console.WriteLine("vyhral si na "+pokus+" pokusu");
                   
                }
            }
        }
    }
}