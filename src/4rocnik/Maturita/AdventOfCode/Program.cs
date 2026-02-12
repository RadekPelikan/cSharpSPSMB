// See https://aka.ms/new-console-template for more information


using var fileStream = File.OpenText("input.txt");

int counter = 0;
int safeValue = 50;
while (fileStream.Peek() != 0)
{
    var line = fileStream.ReadLine();
    if (line is null)
        break;
    Console.WriteLine(line);
    var direction = line[0];
    if (int.TryParse(line.Remove(0, 1), out var value) is false)
    {
        Console.WriteLine("Error happened during parsing number");
    }

    var diff = direction switch
    {
        'L' => -value,
        'R' => value,
    };

    if (Math.Abs(safeValue + diff) > 99)
    {
        ++counter;
    }

    safeValue = (safeValue + diff) % 100;

    if (safeValue == 0)
    {
        ++counter;
    }
}

Console.WriteLine($"Part1: {counter}");