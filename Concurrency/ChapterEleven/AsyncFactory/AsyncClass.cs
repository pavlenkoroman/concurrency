namespace Concurrency.ChapterEleven.AsyncFactory;

public class AsyncClass
{
    private AsyncClass()
    {
    }

    private async Task<AsyncClass> InitializeAsync()
    {
        await Task.Delay(TimeSpan.FromSeconds(5));
        return this;
    }

    public static async Task<AsyncClass> CreateAsync()
    {
        // Невозможно получить неинициализированный экземпляр класса
        var result = new AsyncClass();
        return await result.InitializeAsync();
    }
}