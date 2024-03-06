namespace Concurrency.ChapterEleven.AsyncProperties;

public class AsyncPropertyCachingExample
{
    private CachedAsyncValue<int> _data;

    public CachedAsyncValue<int> Data
    {
        get { return _data; }
    }

    // private readonly CachedAsyncValue<int> _data = new CachedAsyncValue<int>(async () =>
    // {
    //     await Task.Delay(5000);
    //     return 20;
    // });
}