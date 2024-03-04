using System.Threading.Tasks.Dataflow;

namespace Concurrency.ChapterEight.AsyncChannelsWithDataflow;

public static class AsyncEnumerableExtensions
{
    public static async Task WriteToBlockAsync<T>(
        this IAsyncEnumerable<T> enumerable, 
        ITargetBlock<T> block,
        CancellationToken cancellationToken = default)
    {
        try
        {
            await foreach (var item in enumerable.WithCancellation(cancellationToken).ConfigureAwait(false))
            {
                await block.SendAsync(item, cancellationToken).ConfigureAwait(false);
            }
            
            block.Complete();
        }
        catch (Exception e)
        {
            block.Fault(e);
        }
    }
}