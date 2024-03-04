namespace Concurrency.ChapterSeven.TestingAsyncMethod;

public class AsyncChoiceMaker
{
    public async Task<bool> MakeChoiceAsync()
    {
        Console.WriteLine("Думаю...");
        await Task.Delay(1000);
        Console.WriteLine("Долго думаю...");
        await Task.Delay(3000);
        return false;
    }
}