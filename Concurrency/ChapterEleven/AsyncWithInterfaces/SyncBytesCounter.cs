namespace Concurrency.ChapterEleven.AsyncWithInterfaces;

public class SyncBytesCounter : IByteCounter
{
    public Task<int> CountBytesAsync(HttpClient client, string url)
    {
        return Task.FromResult(52);
    }
}