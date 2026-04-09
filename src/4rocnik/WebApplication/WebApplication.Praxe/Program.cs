// See https://aka.ms/new-console-template for more information

using WebApplication.Praxe;
using WebApplication.Praxe.Directory;

using AliasStudent1 = WebApplication.Praxe.Directory.Student;
using AliasStudent2 = WebApplication.Praxe.Test.Student;

public class Program
{
    public static void Main(string[] args)
    {
        Calculator calculator = new Calculator();
        Console.WriteLine(calculator.Sum(20, 30));
        Console.WriteLine("Hello, World!");
        AliasStudent1 st = new AliasStudent1();
        // jednořádkový
        /*
         * fsgfgdsgfds
         * gfdsgfdsgfdsgfds
         * gfdsgfdsgfds
         */
    }
}