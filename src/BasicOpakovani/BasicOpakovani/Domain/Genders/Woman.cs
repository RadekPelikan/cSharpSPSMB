

using System;

namespace BasicOpakovani.Domain
{
    public class Woman : Person
    {
        private static Random rnd = new Random();
        public bool CleanedHouse = false;
        
        public Woman(string name, int age, int weight) : base(name, age, weight)
        {
            PersonGender = Gender.Woman;
        }

        public void Cook(string meal)
        {
            Console.WriteLine($"Cooking {meal}");
        }

        public bool CleanHouse()
        {
            Console.WriteLine("Cleaning house");
            int chance = rnd.Next(100);
            
            if (chance < 10)
            {
                Console.WriteLine("House cleaned");
                CleanedHouse = true;
                return true;
            }
            else
            {
                Console.WriteLine("Mission failed, better luck next time");
                CleanedHouse = false;
                return false;
            }
        }
    }
}
