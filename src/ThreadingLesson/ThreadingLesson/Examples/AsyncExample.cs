namespace ThreadingLesson;

public class AsyncExample
{
    static async Task Run()
    {
        string data = await GetDataAsync("https://example.com");
        Console.WriteLine(data);
    }

    static async Task<string> GetDataAsync(string url)
    {
        using HttpClient client = new HttpClient();
        return await client.GetStringAsync(url);
    }
}