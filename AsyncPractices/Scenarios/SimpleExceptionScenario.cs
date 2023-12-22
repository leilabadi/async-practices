namespace Async_Practices.Scenarios;

public class SimpleExceptionScenario : AsyncBase
{
    public override async Task Run()
    {
        PrintMessage($"Beginning of {nameof(SimpleExceptionScenario)}");
        Console.WriteLine();

        Task task = MethodWithExceptionAsync();
        PrintMessage("After getting task for async method");
        
        try
        {
            await task;
        }
        catch (Exception e)
        {
            PrintMessage($"Caught Exception from async method - Message: {e.Message}");
        }
        
        Console.WriteLine();
        PrintMessage($"End of {nameof(SimpleExceptionScenario)}");
    }

    private async Task MethodWithExceptionAsync()
    {
        throw new Exception("Testing async exceptions!");
    }
}