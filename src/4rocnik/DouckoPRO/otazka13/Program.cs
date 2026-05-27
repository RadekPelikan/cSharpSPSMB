// See https://aka.ms/new-console-template for more information

using System.Runtime.InteropServices;

Console.WriteLine("Hello, World!");

/**
 * Vytvořte program, který využije procesor na 100% za využití vláken, je třeba rozjet tolik vláken, kolik máme na CPU logických procesorů
 * 
 */


void DoWork()
{
    while(true)
    {
        Math.Sqrt(10e14);
    }
}

for (int i = 0; i < 12; i++)
{
    new Thread(DoWork).Start();
}


