namespace Concurrency.ChapterEleven.AsyncDispose;

public class AsyncDisposeViaCancellation : IDisposable
{
    private readonly CancellationTokenSource _disposeCts = new();

    public async Task<int> CalculateValueAsync()
    {
        await Task.Delay(TimeSpan.FromSeconds(6), _disposeCts.Token);
        return 52;
    }

    public async Task<int> CalculateValueAsync(CancellationToken cancellationToken)
    {
        using var combinedCts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken, _disposeCts.Token);
        await Task.Delay(TimeSpan.FromSeconds(10), combinedCts.Token);
        return 52;
    }


    public void Dispose()
    {
        _disposeCts.Cancel();
        _disposeCts.Dispose();
    }
}