using Iterator;

TestNejaky testNejaky = new TestNejaky("Ahoj", new TestNejaky("Ahoj2", new TestNejaky("Ahoj3", new TestNejaky("Ahoj4"))));
TestAhoj testAhoj = new TestAhoj("A", new TestAhoj("B"));

TestNejaky currentNejaky = testNejaky;
Console.WriteLine(currentNejaky.GetText());
while ((currentNejaky = currentNejaky.Next()) != null)
{
    Console.WriteLine(currentNejaky.GetText());
}

TestAhoj currentAhoj = testAhoj;
Console.WriteLine(currentAhoj.GetText());
while ((currentAhoj = currentAhoj.Next()) != null)
{
    Console.WriteLine(currentAhoj.GetText());
}
