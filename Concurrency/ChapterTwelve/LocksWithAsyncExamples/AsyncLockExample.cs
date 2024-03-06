using Nito.AsyncEx;

namespace Concurrency.ChapterTwelve.LocksWithAsyncExamples;

public class AsyncLockExample
{
    private readonly AsyncLock _asyncLock = new AsyncLock();

    private int _value;

    public async Task DelayAndIncrementAsync()
    {
        using (await _asyncLock.LockAsync())
        {
            var oldValue = _value;
            await Task.Delay(TimeSpan.FromSeconds(oldValue));
            _value = oldValue + 1;
        }
    }
}