using System.Text.RegularExpressions;
using OopExamples.Interfaces;
using OopExamples.Interfaces.Exceptions;

namespace OopExamples.Classes;

public class Computer:IComputer
{
   public IEntity Owner { get; set; }
    public IMotherBoard MotherBoard { get; init; }
    public ICPU Cpu { get; init; }
    public IGPU Gpu { get; init; }
    public IRAM Ram { get; init; }
    public IPowerSupply PowerSupply { get; init; }
    public ICase Case { get; init; }
    public IMonitor[] Monitors { get; init; }
    public bool IsOn { get; set; }
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
        if (IsOn)
        {
            ShutDown();
            
        }
        else
        {
            PowerUp();
        }
    }

    public void Print(string text)
    {
        Console.WriteLine($"[COMPUTER]: {text}");
    }
    

    public float Compute(string equation)
    {
        equation.Replace(".", ",");

        string[] splitProblem = Regex.Split(equation, @"\s+")
            .Where(s => !string.IsNullOrWhiteSpace(s))
            .ToArray();
        double finished = 0;

        double firstNumber = Double.Parse(splitProblem[0].Replace(".", ","));
        double secondNumber = Double.Parse(splitProblem[2].Replace(".", ","));

        switch (splitProblem[1])
        {
            case "+": 
                finished = firstNumber + secondNumber; 
                break;
            case "-": 
                finished = firstNumber - secondNumber; 
                break;
            case "*": 
                finished = firstNumber * secondNumber; 
                break;
            case "/": 
                finished = firstNumber / secondNumber; 
                break;
            case "**": 
                finished = Math.Pow(firstNumber, secondNumber); 
                break;
            default: 
                throw new InvalidEquationException();
        }
        return (float)finished;
    }

    public void ChangeOwner(IEntity? newOwner)
    {
        if (newOwner == null)
        {
            RemoveOwner();
            return;
        }

        if (newOwner.GetType() == typeof(Person))
        {
            Owner = (Person)newOwner;
            IsPersonalPC = true;
            IsCompanyPC = false;
        }
        else if (newOwner.GetType() == typeof(Company))
        {
            Owner = (Company)newOwner;
            IsPersonalPC = false;
            IsCompanyPC = true;
        }
    }

    public void RemoveOwner()
    {
        Owner = null;
        IsCompanyPC = false;
        IsPersonalPC  = false;
    }

    public IComputer BuildNewComputer(IComputerConfiguration configuration)
    {
        return new Computer
        {
            MotherBoard = configuration.MotherBoard,
            Cpu = configuration.Cpu,
            Gpu = configuration.Gpu,
            Ram = configuration.Ram,
            PowerSupply = configuration.PowerSupply,
            Case = configuration.Case,
        };
    }
}