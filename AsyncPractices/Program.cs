using Async_Practices.Scenarios;
using System;

namespace Async_Practices;

public class Program
{
    public static async Task Main(string[] args)
    {
        PrintMessage("Beginning of main method");

        //await new SimpleAsyncCalls().Run();

        //await new DeadlockSituations().Run();

        //await new SimpleExceptionScenario().Run();

        await new MultipleExceptionScenario().Run();

        PrintMessage("End of main method");
    }

    private static void PrintMessage(string message)
    {
        Console.WriteLine($"Thread: {Thread.CurrentThread.ManagedThreadId} - {message}");
    }
}