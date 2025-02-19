// See https://aka.ms/new-console-template for more information

Console.WriteLine("Napiste regex: ");
string regex = Console.ReadLine();
Console.WriteLine("Napiste string pro testovani regexu: ");
string value = Console.ReadLine();
if (true)
    Console.WriteLine("Regex sedi s hodnotou");
else
    Console.WriteLine("Regex nesedi s hodnotou");


///// CAST 2

// https://github.com/commandlineparser/commandline
// pouziti programu: regexApp.exe -r "\d+" -v 3425
// vyprintuje "Regex sedi", "Regex nesedi"


///// CAST 3

// regexApp.exe regexValues.txt -o results.txt
// regexValues.txt obashuje:
// prvni radek: (regex) | pod nim dalsi radky hodonty pro otestovani

// \d+
// 4546
// 45 fgh
// 5436

// vystupni soubor:
// 1: sedi
// 2: nesedi
// 3: sedi
