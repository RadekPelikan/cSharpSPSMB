// See https://aka.ms/new-console-template for more information

/**
 * Udělejte třídu TextNormalizer, která má na sobě metodu string Normalize(string text)
 * Interně bude mít definovaný array hodnot, který bude mazat z toho textu
 * [".", "!?", "@@", "??", "!!", "()"]
 *
 * Vytvořte si Vyjímku TextNormalizationException, která se vyhodí z Normalize(), pokud výsledný text je prázdný
 *
 * Napište 3 testy na tento TextNormalizer
 * - "ahoj !!" => "ahoj "
 * - "ahoj" => "ahoj"
 * - "!!!?" => vyhodí vyjímku
 */

var normalized = new TextNormalizer().Normalize("Ahoj.. !?");
Console.WriteLine(normalized);

throw new TextNormalizationException();