// See https://aka.ms/new-console-template for more information

Console.WriteLine("Hello, World!");

var alphabet = "ABCDEFGHIJ";
// existuje abeceda: ABCDEFGHIJ
// Vytvořte pole čísel od 0 do 10_000

var word = "HA";
var i = 0;
var numbers = new int[10_000].Select(e => i++);
var words = numbers
    .Select(n => 
        string.Join("", 
            n.ToString().Select((c, i) => alphabet[c - '0'])
            )
        )
    .ToList();
var count = words.Count(e => e.Contains(word));

Console.WriteLine(count);
// každé číslo v poli převeďte na abecedu
// 0 = A
// 10 = BA
// 111 = BBB
// 9999 = JJJJ
// 7070 = HAHA

// LINQ - Select, Where, Count
// Vyhodnoťte kolikrát se v tomto poli zobrazí slovo "HA"

// výsledek:
// HA nalezeno: 70 krát
