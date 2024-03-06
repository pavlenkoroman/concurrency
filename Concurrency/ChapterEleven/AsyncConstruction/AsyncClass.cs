namespace Concurrency.ChapterEleven.AsyncConstruction;

public class AsyncClass : IAsyncInitializable
{
    public Task Initialization { get; }

    public AsyncClass()
    {
        Initialization = InitializeAsync();
    }

    private async Task InitializeAsync()
    {
        await Task.Delay(TimeSpan.FromSeconds(5));
    }
}