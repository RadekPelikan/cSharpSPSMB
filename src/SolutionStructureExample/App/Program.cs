using System;
using System.Collections.Generic;
using System.IO;
using ConsoleLibrary;
using FileLibrary;

namespace App
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "./res/movies.csv";

            CsvParser parser = new CsvParser(path);
            
            string text = parser.ReadFile();
            Console.WriteLine(text);
        }
    }

}