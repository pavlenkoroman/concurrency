namespace Concurrency.ChapterEleven.AsyncWithInterfaces;

public static class BytesCounterConsumer
{
    public static async Task Execute()
    {
        using var client = new HttpClient();
        await UseServiceAsync(client, new ByteCounter());
    }
    
    private static async Task UseServiceAsync(HttpClient client, IByteCounter service)
    {
        var result = await service.CountBytesAsync(client, "google.com");
        Console.WriteLine(result);
    }
}