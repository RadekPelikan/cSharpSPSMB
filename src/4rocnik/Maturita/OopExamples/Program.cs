class Program
{
    static void Main(string[] args)
    {
        IComputerBuilder builder = new ComputerBuilder();
        IComputer myPC = builder.Build();

        Console.WriteLine(myPC);
    }
}