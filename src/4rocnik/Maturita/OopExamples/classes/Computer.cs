using OopExamples.Interfaces;

namespace OopExamples.classes;

public class Computer : IComputer
{
    public IEntity Owner { get; set; }
    public IMotherBoard MotherBoard { get; set; }
    public ICPU Cpu { get; set; }
    public IGPU Gpu { get; set; }
    public IRAM Ram { get; set; }
    public IPowerSupply PowerSupply { get; set; }
    public ICase Case { get; set; }
    public IMonitor[] Monitors { get; set; }
    public bool IsOn { get; private set; }
    public bool IsPersonalPC { get; set; }
    public bool IsCompanyPC { get; set; }
    
    public void PowerUp()
    {
        IsOn = true;
    }

    public void ShutDown()
    {
        IsOn = false;
    }

    public void PressPowerButton()
    {
        if(!IsOn) PowerUp();
        else ShutDown();
    }

    public void Print(string text)
    {
        Console.WriteLine(text);
    }

    public float Compute(string equation)
    {
        List<string> tokens = null;
        tokens = Tokenize(equation.Replace(".", ","));
        if (tokens.Count != 3)
        {
            throw new Exception("Špatně zadaný příklad");
        }

        float n1 = 0;
        float n2 = 0;
        try
        {
            n1 = float.Parse(tokens[0]);
            n2 = float.Parse(tokens[2]);
        }
        catch (Exception e)
        {
            throw new Exception("Špatně zadaný příklad");
        }

        return Calculate(n1, n2, tokens[1]);
    }
    
    public float Calculate(float n1, float n2, string s)
    {
        switch (s)
        {
            case "+":
            {
                return n1 + n2;
            }
            case "-":
            {
                return n1 - n2;
            }
            case "*":
            {
                return n1 * n2;
            }
            case "/":
            {
                return n1 / n2;
            }
            case "**":
            {
                return (float) Math.Pow(n1, n2);
            }
        }
        throw new Exception("Špatně zadaný příkaz");
    }

    public List<String> Tokenize(string s)
    {
        List<String> tokens = new List<String>();
        string currentToken = "";
        char[] chars = s.ToCharArray();
        for (int i = 0; i < chars.Length; i++)
        {
            if (chars[i] == ' ')
            {
                if (!currentToken.Equals(""))
                {
                    tokens.Add(currentToken);
                    currentToken = "";
                }
            }
            else
            {
                currentToken += chars[i];
            }
        }
        if(!currentToken.Equals("")) tokens.Add(currentToken);
        return tokens;
    }

    public void ChangeOwner(IEntity? newOwner)
    {
        Owner = newOwner;
        IsPersonalPC = Owner is Person;
        IsCompanyPC = Owner is Company;
    }

    public void RemoveOwner()
    {
        Owner = null;
        IsPersonalPC = false;
        IsCompanyPC = false;
    }

    public IComputer BuildNewComputer(IComputerConfiguration configuration)
    {
        return new ComputerBuilder().AddCase(configuration.Case)
            .AddCPU(configuration.Cpu)
            .AddGPU(configuration.Gpu)
            .AddMotherBoard(configuration.MotherBoard)
            .AddPowerSupply(configuration.PowerSupply)
            .AddRam(configuration.Ram)
            .Build();
    }
}