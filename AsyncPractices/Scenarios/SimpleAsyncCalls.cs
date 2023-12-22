namespace Async_Practices.Scenarios;

public class SimpleAsyncCalls : AsyncBase
{
    public override async Task Run()
    {
        PrintMessage($"Beginning of {nameof(SimpleAsyncCalls)}");
        Console.WriteLine();

        Task task = IoBoundOperationAsync();
        PrintMessage("After getting task for async method");
        await task;
        PrintMessage("Continuation of async method");

        Console.WriteLine();

        task = Task.Run(CpuBoundOperation);
        PrintMessage("After getting task for method group Task.Run");
        await task;
        PrintMessage("Continuation of method group Task.Run");

        task = Task.Run(async () =>
        {
            PrintMessage("Beginning of lambda Task.Run");
            await IoBoundOperationAsync();
            PrintMessage("End of lambda Task.Run");
        });
        PrintMessage("After getting task for lambda Task.Run");
        await task;
        PrintMessage("Continuation of lambda Task.Run");

        Console.WriteLine();

        Console.WriteLine();
        PrintMessage($"End of {nameof(SimpleAsyncCalls)}");
    }
}