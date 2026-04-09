// See https://aka.ms/new-console-template for more information

using System.Runtime.InteropServices.ComTypes;var day = DayOfWeek.Saturday;
bool isWeekend = false;
switch (day)
{
    case DayOfWeek.Saturday:
    case DayOfWeek.Sunday:
        isWeekend = true;
        break;
    default:
        isWeekend = false;
        break;
}

var dowt = new DayOfWeekType(DayOfWeek.Saturday, true);
DayOfWeekType.Test();
dowt.Overload((double) 1);

bool _isWeekend = dowt switch
{
    {isWeekend: true} => true,
    _ => false
};

var text = "ahoj";

Console.WriteLine($"{day} is weekend: {isWeekend}");
Console.WriteLine($"{day} is weekend: {_isWeekend}");

record DayOfWeekType(DayOfWeek dow, bool isWeekend)
{
    public static void Test()
    {
        Console.WriteLine("Hello");
    }

    public void Overload(int a)
    {
        Console.WriteLine("OVERLOAD INT");
    }
    public void Overload(double a)
    {
        Console.WriteLine("OVERLOAD DOUBLE");
    }
}