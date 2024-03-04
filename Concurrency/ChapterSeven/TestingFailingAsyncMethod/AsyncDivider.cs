namespace Concurrency.ChapterSeven.TestingFailingAsyncMethod;

public class AsyncDivider
{
    public async Task<int> DivideAsync(int a, int b)
    {
        await Task.Delay(1000);
        return a / b;
    }
}