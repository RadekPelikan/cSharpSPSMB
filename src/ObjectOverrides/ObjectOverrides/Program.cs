
var pepa1 = new Person("Pepa Novak");
var pepa2 = new Person("Pepa Novak");
var filip = new Person("Filip Novotny");

if (pepa1 == pepa2)
{
    Console.WriteLine("Jsou to stejni bludi");
}
else
{
    Console.WriteLine("Nejsme stejni");
}

System.Collections.Generic.HashSet<string> set = new HashSet<string>();

set.Add("ahoj");
set.Add("nazdar");
set.Add("ahoj");

Console.WriteLine(string.Join(" ", set));