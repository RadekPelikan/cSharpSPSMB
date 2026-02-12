var size = 1000;

List<int> list = new List<int>(size);
for (int i = 0; i < size; i++)
{
    list.Add(i + 1);
}


var fizzbuzz = list
    .Select(c => (name: string.Empty, value: c))
    .Select(c => c.value % 3 == 0 ? c with { name = c.name + "fizz" } : c)
    .Select(c => c.value % 5 == 0 ? c with { name = c.name + "buzz" } : c)
    .Select(c => c.value % 7 == 0 ? c with { name = c.name + "kezz" } : c)
    .Select(c => c.value % 9 == 0 ? c with { name = c.name + "bum" } : c)
    .Select(c => c.value % 11 == 0 ? c with { name = c.name + "bac" } : c)
    .Select(c => c.name == string.Empty ? c.value.ToString() : c.name);

foreach (var i in fizzbuzz)
{
    Console.WriteLine(i);
}