namespace Async_Practices.Scenarios;

public class AsyncBase
{
    protected void PrintMessage(string message)
    {
        Console.WriteLine($"Thread: {Thread.CurrentThread.ManagedThreadId} - {message}");
    }

    protected async Task IoBoundOperationAsync()
    {
        PrintMessage("Beginning of async IO operation");
        var client = new HttpClient();
        var response = await client.GetAsync("https://www.google.com");
        await response.Content.ReadAsStringAsync();
        PrintMessage("End of async IO operation");
    }

    protected void CpuBoundOperation()
    {
        PrintMessage("Beginning of async CPU operation");
        for (int i = 0; i < 5; i++)
        {
            PrintMessage($"Work Item {i}");
            // Simulate CPU-bound work
            for (int j = 0; j < 100000000; j++) { }
        }
        PrintMessage("End of async CPU operation");
    }

    protected async Task WaitAsync()
    {
        PrintMessage("Beginning of async wait");
        await Task.Delay(2000);
        PrintMessage("End of async wait");
    }
}