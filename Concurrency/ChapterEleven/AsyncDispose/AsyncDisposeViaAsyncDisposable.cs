namespace Concurrency.ChapterEleven.AsyncDispose;

public class AsyncDisposeViaAsyncDisposable : IAsyncDisposable
{
    public async ValueTask DisposeAsync()
    {
        await Task.Delay(TimeSpan.FromSeconds(10));
    }
}