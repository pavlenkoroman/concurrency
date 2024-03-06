namespace Concurrency.ChapterEleven.AsyncWithInterfaces;

public interface IByteCounter
{
    // async НЕ ОТНОСИТСЯ К СИГНАТУРЕ МЕТОДА
    Task<int> CountBytesAsync(HttpClient client, string url);
}