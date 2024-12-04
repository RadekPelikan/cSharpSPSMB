namespace FileParser;

public class Currency
{
    public string Value;
    public decimal Amount;

    public Currency(string value, decimal amount)
    {
        Value = value;
        Amount = amount;
    }
}