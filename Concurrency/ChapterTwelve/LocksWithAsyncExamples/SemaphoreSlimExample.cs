namespace Concurrency.ChapterTwelve.LocksWithAsyncExamples;

public class SemaphoreSlimExample
{
    private readonly SemaphoreSlim _semaphoreSlim = new SemaphoreSlim(1);
    private int _value;

    public async Task DelayAndIncrementAsync()
    {
        await _semaphoreSlim.WaitAsync();
        try
        {
            var oldValue = _value;
            await Task.Delay(TimeSpan.FromSeconds(oldValue));
            _value = oldValue + 1;
        }
        finally
        {
            // если код в блоке try выдаст исключение, освобождение потока в семафоре всё равно произойдёт
            _semaphoreSlim.Release();
        }
    }
}