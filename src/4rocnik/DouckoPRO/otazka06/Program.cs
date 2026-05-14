// See https://aka.ms/new-console-template for more information

using otazka06;

Console.WriteLine("Hello, World!");


// každé číslo v poli převeďte na abecedu

// existuje abeceda: ABCDEFGHIJ
// Vytvořte pole čísel od 0 do 10_000
// 0 = A
// 10 = BA
// 111 = BBB
// 9999 = JJJJ
// 7070 = HAHA

// LINQ - Select, Where, Count
// Vyhodnoťte kolikrát se v tomto poli zobrazí slovo "HA"

// výsledek:
// HA nalezeno: 70 krát
// Run.Task03();

// Zadání 4.
// Objednávky, kde jedna hodnta je předmět nákupu a druhá hodnota je počet položek
// Následovný vstup:
// jablko:4
// rohlik:5
// pomeranc:4
// jablko:6
// sroubovak:1
// vejce:20
// vejce:5
// \n

var itemCounts = new List<string>().ToDictionary(line => line, line => 5);
// jablko:4 -> string item; int count;
// 
var items = new Dictionary<string, int>();
// vystup:
// jabko, 10
// rohlik, 5
// pomeranc, 4
// sroubovak, 1
// vejce, 25

// potrebne LINQ metody: .Select(), .Where(), .Count(), .ToDictionary()