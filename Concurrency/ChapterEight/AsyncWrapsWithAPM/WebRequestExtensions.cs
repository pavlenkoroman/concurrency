using System.Net;

namespace Concurrency.ChapterEight.AsyncWrapsWithAPM;

public static class WebRequestExtensions
{
    public static Task<WebResponse> GetResponseAsync(this WebRequest client)
    {
        return Task<WebResponse>.Factory.FromAsync(client.BeginGetResponse, client.EndGetResponse, null);
    }
}