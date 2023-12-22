namespace Async_Practices.Scenarios;

public class MultipleExceptionScenario : AsyncBase
{
    public override async Task Run()
    {
        PrintMessage($"Beginning of {nameof(MultipleExceptionScenario)}");
        Console.WriteLine();

        Task task1 = MethodWithException1Async();
        Task task2 = MethodWithException2Async();
        Task task3 = Task.Run(() => throw new ApplicationException("Inline task exception 1"));
        Task task4 = Task.Run(() => throw new ApplicationException("Inline task exception 2"));

        PrintMessage("After getting all tasks for Task.WhenAll");

        var allTasks = Task.WhenAll(task1, task2, task3, task4);
        PrintMessage("After getting task from Task.WhenAll");

        try
        {
            await allTasks;
        }
        catch (Exception e)
        {
            PrintMessage($"Caught Exception from async method - Message: {e.Message}");

            AggregateException? aggregateException = allTasks.Exception;
            if (aggregateException != null)
            {
                foreach (var ex in aggregateException.Flatten().InnerExceptions)
                {
                    PrintMessage($"Inner Exception - Message: {ex.Message}");
                }
            }
        }

        Console.WriteLine();
        PrintMessage($"End of {nameof(MultipleExceptionScenario)}");
    }

    private async Task MethodWithException1Async()
    {
        await Task.Delay(2000);
        throw new ApplicationException("Method exceptions 1");
    }

    private async Task MethodWithException2Async()
    {
        await Task.Delay(1000);
        throw new ApplicationException("Method exceptions 2");
    }
}