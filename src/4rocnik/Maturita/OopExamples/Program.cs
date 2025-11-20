// See https://aka.ms/new-console-template for more information

var day = DayOfWeek.Monday;

string GetDay(DayOfWeek day)
{
    switch (day)
    {
        case DayOfWeek.Saturday:
        case DayOfWeek.Sunday:
            return "Víkend";
        default:
            return "Pracovní den";
    }
}

// Console.WriteLine(GetDay(day));

var num = 154.345435f;
Person p1 = null; //new Person("Petr", 19)
// {
//     Name = "Pepa",
// };


var tuple1 = ("ahoj", 10);
var tuple2 = (msg: "ahoj", num: 10);

Console.WriteLine(tuple1.Item1);
Console.WriteLine(tuple2.Item1);
Console.WriteLine(tuple2.num);

record Person(string Name, int Age);
