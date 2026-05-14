// See https://aka.ms/new-console-template for more information


/**
 * Zadání 1.
 * Vytvořte metodu Min(double a, double b), vrátí menší hodnotu
 * Vytvořte přetížení metody Min(DateTime a, DateTime b), vrátí dřívější čas
 * Vytvořte přetížení metody Min(string a, string b), vrátí kratší string
 *
 * Zadání 2.
 * Vytvořte generickou třídu Storage<T>
 * obsahuje readonly property T Data
 * obsahuje readonly property DateTime CreatedAt
 *
 * Hodnota bude nastavena v konstruktoru
 * Vytvořte ukázku generického Storage
 */

var value = new Storage<string>("ahoj");
Console.WriteLine(value);

Thread.Sleep(1000);
var valueList = new Storage<List<string>>(["ahoj"]);
Console.WriteLine(valueList);
