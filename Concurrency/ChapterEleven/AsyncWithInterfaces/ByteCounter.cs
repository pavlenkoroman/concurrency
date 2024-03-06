namespace Concurrency.ChapterEleven.AsyncWithInterfaces;

public class ByteCounter : IByteCounter
{
    // async относится к реализации метода
    public async Task<int> CountBytesAsync(HttpClient client, string url)
    {
        var bytesArray = await client.GetByteArrayAsync(url);
        return bytesArray.Length;
    }
}