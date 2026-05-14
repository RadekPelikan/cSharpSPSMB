using System.Text.RegularExpressions;

namespace otazka07;

public class Run
{
    public static void Task01()
    {
        var input = "+444    \t 555 444 333    ";

        Console.WriteLine(Regex.IsMatch(input, @"^\+\d{1,3}\s+\d{3}\s+\d{3}\s+\d{3}\s*$"));
    }

    public static void Task02()
    {
        var text = @"
Dobrý den,
kontaktujte mě prosím na:
jan.novak@email.cz  ff
+420 775 123 456

Adresa:
Květná 15
293 01 Mladá Boleslav
";

        var match = Regex.Match(text, @"\s*(\S+@\S+)\s*");
        Console.WriteLine($"Email: {match.Value}");
    }
}
