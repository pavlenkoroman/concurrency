namespace Concurrency.ChapterEight.AsyncWrapsForEverything;

public static class AsyncHttpServiceExtensions
{
    public static Task<string> DownloadStringAsync(this IAsyncHttpService httpService, Uri address)
    {
        var tcs = new TaskCompletionSource<string>();
        httpService.DownloadString(address, (result, exception) =>
        {
            if (exception != null)
            {
                tcs.TrySetException(exception);
            }
            else
            {
                tcs.TrySetResult(result);
            }
        });

        return tcs.Task;
    }
}