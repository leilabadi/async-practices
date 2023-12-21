namespace Async_Practices;

public class Program
{
    private static readonly string Url = "https://www.google.com";

    public static async Task Main(string[] args)
    {
        var result = await GetContentAsync();
        Console.WriteLine(result);
    }

    private static async Task<string> GetContentAsync()
    {
        var client = new HttpClient();
        var response = await client.GetAsync(Url);
        var content = await response.Content.ReadAsStringAsync();
        return content;
    }
}