using System;


namespace setup
{
    internal class Program
    {
        public static void Main(string[] args)
        {
           // Fizzbuzz();
           // NumberGuessing();
           string ans = Calculator.Calculate(Console.ReadLine());
           Console.WriteLine(ans);
        }

        private static void Fizzbuzz()
        {
            for (int i = 1; i <= 100; i++)
            {
                string word = "";
                if (i % 3 == 0)
                {
                    word += "Fizz";
                }
                if (i % 5 == 0)
                {
                    word += "Buzz";
                }

                if (word.Length > 0)
                {
                    Console.WriteLine(word);
                    continue;
                }
                
                Console.WriteLine(i);
            }
        }

        private static void NumberGuessing()
        {
            Random random = new Random();
            int randomNumber = random.Next(0, 101);
            bool isGuessed = false;
            while (!isGuessed)
            {
                bool isNumber = int.TryParse(Console.ReadLine(), out int userGuess);
                if (!isNumber) continue;
                
                if (userGuess > randomNumber)
                {
                    Console.WriteLine("moc velky");
                    continue;
                }

                if (userGuess < randomNumber)
                {
                    Console.WriteLine("moc maly");
                    continue;
                }

                if (userGuess == randomNumber)
                {
                    Console.WriteLine("spravny");
                    isGuessed = true;
                }
            }
        }
        
    }
}