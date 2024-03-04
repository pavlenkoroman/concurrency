using System.Runtime.CompilerServices;
using System.Threading.Tasks.Dataflow;

namespace Concurrency.ChapterEight.AsyncChannelsWithDataflow;

public static class SourceBlockExtensions
{
    public static bool TryReceiveItem<T>(this ISourceBlock<T> block, out T value)
    {
        if (block is IReceivableSourceBlock<T> receivableSourceBlock)
        {
            return receivableSourceBlock.TryReceive(out value);
        }

        try
        {
            value = block.Receive(TimeSpan.Zero);
            return true;
        }
        catch (TimeoutException)
        {
            value = default;
            return false;
        }
        catch (InvalidOperationException)
        {
            value = default;
            return false;
        }
    }

    public static async IAsyncEnumerable<T> ReceiveAllAsync<T>(
        this ISourceBlock<T> block,
        [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        while (await block.OutputAvailableAsync(cancellationToken).ConfigureAwait(false))
        {
            while (block.TryReceiveItem(out var value))
            {
                yield return value;
            }
        }
    }
}