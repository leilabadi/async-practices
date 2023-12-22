namespace Async_Practices.Scenarios;

public class DeadlockSituations : AsyncBase
{
    public override async Task Run()
    {
        PrintMessage($"Beginning of {nameof(DeadlockSituations)}");
        Console.WriteLine();

        Task task = Task.Run(WaitAsync);
        PrintMessage("After getting task for method group Task.Run");
        await task;
        PrintMessage("Continuation of method group Task.Run");

        Console.WriteLine();

        task = Task.Run(async () =>
        {
            PrintMessage("Beginning of lambda Task.Run");
            await WaitAsync();
            PrintMessage("End of lambda Task.Run");
        });
        PrintMessage("After getting task for lambda Task.Run");
        await task;
        PrintMessage("Continuation of lambda Task.Run");

        Console.WriteLine();
        PrintMessage($"End of {nameof(DeadlockSituations)}");
    }
}