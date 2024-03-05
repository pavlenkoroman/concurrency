using System.Collections.Immutable;

namespace Concurrency.ChapterNine.ImmutableStacksAndQueues;

public static class ImmutableQueueExample
{
    public static void ExecuteSimpleImmutableQueueExample()
    {
        var queue = ImmutableQueue<int>.Empty;
        queue = queue.Enqueue(10);
        queue = queue.Enqueue(20);

        foreach (var item in queue)
        {
            Console.WriteLine(item);
        }

        queue = queue.Dequeue(out var lastItem);
        Console.WriteLine(lastItem);
    }
}