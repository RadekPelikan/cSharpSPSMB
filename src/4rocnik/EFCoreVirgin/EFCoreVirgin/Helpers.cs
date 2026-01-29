namespace EFCoreVirgin;

public class Helpers
{
    public static string ReadSecret(string prompt = "")
    {
        System.Console.Write(prompt);
        string password = "";
        while (true)
        {
            var key = System.Console.ReadKey(true);
            if (key.Key == ConsoleKey.Enter)
                break;
            password += key.KeyChar;
        }

        Console.WriteLine();
        return password;
    }
}