namespace Async_Practices;

public class Program
{
    private static readonly string Url = "https://www.google.com";

    public static async Task Main(string[] args)
    {
        PrintMessage("Beginning of main method");

        Console.WriteLine();

        Task task = IoBoundOperationAsync();
        PrintMessage("After getting task for async method");
        await task;
        PrintMessage("After awaiting async method completion");

        Console.WriteLine();

        task = Task.Run(async () =>
        {
            PrintMessage("Beginning of lambda Task.Run");
            await IoBoundOperationAsync();
            PrintMessage("End of lambda Task.Run");
        });
        PrintMessage("After getting task for lambda Task.Run ");
        await task;
        PrintMessage("After awaiting lambda Task.Run completion");

        Console.WriteLine();

        task = Task.Run(CpuBoundOperation);
        PrintMessage("After getting task for inline Task.Run");
        await task;
        PrintMessage("After awaiting inline Task.Run");

        Console.WriteLine();

        PrintMessage("End of main method");
    }

    private static async Task IoBoundOperationAsync()
    {
        PrintMessage("Beginning of async IO operation");
        var client = new HttpClient();
        var response = await client.GetAsync(Url);
        await response.Content.ReadAsStringAsync();
        PrintMessage("End of async IO operation");
    }

    static void CpuBoundOperation()
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

    private static void PrintMessage(string message)
    {
        Console.WriteLine($"Thread: {Thread.CurrentThread.ManagedThreadId} - {message}");
    }
}