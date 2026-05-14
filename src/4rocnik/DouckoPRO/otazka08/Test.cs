public class Test
{
    double Min(double a, double b)
        => a < b ? a : b;

    DateTime Min(DateTime a, DateTime b)
        => a < b ? a : b;

    string Min(string a, string b)
        => a.Length < b.Length ? a : b;
}