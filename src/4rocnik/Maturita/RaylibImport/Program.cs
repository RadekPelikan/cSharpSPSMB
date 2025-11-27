
Console.WriteLine("Hello, World!");
// ukaz jak funguji Thread, ThreadPool, Task
// Jake jsou rozdily mezi nimi?

public class Example
{
    public async void ExampleO()
    {
        Thread thread = new Thread(Example1);
        ThreadPool.QueueUserWorkItem(state => {});
        
        Task.WaitAll();
    }

    public void Example1()
    {
        
    }
}

// Naimplementuj Raylib class pro nalinkovani libraylib.dll

// Pro dllimport pouzij pouze nazev souboru raylib.dll
