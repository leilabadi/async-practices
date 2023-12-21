namespace Async_Practices.Scenarios;

public class DeadlockSituations : AsyncBase
{
    public async Task RunTests()
    {
        PrintMessage($"Beginning of {nameof(DeadlockSituations)}");
        Console.WriteLine();

        Task task = Task.Run(WaitAsync);
        PrintMessage("After getting task for method grpoup Task.Run ");
        await task;
        PrintMessage("Continuation of method grpoup Task.Run completion");

        Console.WriteLine();

        task = Task.Run(async () =>
        {
            PrintMessage("Beginning of lambda Task.Run");
            await WaitAsync();
            PrintMessage("End of lambda Task.Run");
        });
        PrintMessage("After getting task for lambda Task.Run ");
        await task;
        PrintMessage("Continuation of lambda Task.Run completion");


        Console.WriteLine();
        PrintMessage($"End of {nameof(DeadlockSituations)}");
    }
}