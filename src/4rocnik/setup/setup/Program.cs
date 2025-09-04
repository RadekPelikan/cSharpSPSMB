using System;

namespace setup
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Fizzbuzz();
            NumberGuessing();
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

        private static void Calculator()
        {
            string firstNumberText, secondNumberText, operatorText;  
            int firstNumberParsed, secondNumberParsed;
            
            string line =  Console.ReadLine();
            string[] split = line.Split(' ');
            
            firstNumberText = split[0];
            operatorText = split[1];
            secondNumberText = split[2];
            
            int.TryParse(firstNumberText, out int firstNumberParsed);
            int.TryParse(secondNumberText, out int secondNumberParsed);
            
        }
    }
}