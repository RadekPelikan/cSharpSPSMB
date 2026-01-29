using System;

namespace StrategyPattern
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Dog pes = new Dog("hafan", 2, 100, false);
            Memento.Save(pes);

            Console.WriteLine(pes);
            pes.Age = 8;
            pes.NumberOfBarks = 4;
            Console.WriteLine(pes);
            
            pes = Memento.GetSavedDog();
            Console.WriteLine(pes);
        }

        
    }
}