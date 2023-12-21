using Async_Practices.Scenarios;

namespace Async_Practices;

public class Program
{
    public static async Task Main(string[] args)
    {
        PrintMessage("Beginning of main method");

        await new SimpleAsyncCalls().RunTests();

        //await new DeadlockSituations().RunTests();

        PrintMessage("End of main method");
    }

    private static void PrintMessage(string message)
    {
        Console.WriteLine($"Thread: {Thread.CurrentThread.ManagedThreadId} - {message}");
    }
}