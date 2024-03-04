namespace Concurrency.ChapterEight.AsyncWrapsForEverything;

public interface IAsyncHttpService
{
    void DownloadString(Uri address, Action<string, Exception> callback);
}