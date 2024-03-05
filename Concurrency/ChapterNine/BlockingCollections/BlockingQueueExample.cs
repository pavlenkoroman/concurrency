using System.Collections.Concurrent;

namespace Concurrency.ChapterNine.BlockingCollections;

public class BlockingQueueExample
{
    private static readonly BlockingCollection<int> _blockingCollection = new BlockingCollection<int>();

    public static void ExecuteBlockingCollectionExample()
    {
        // Поток-производитель добавляет значения и сигнализирует, что _blockingCollection больше не добавляет значенияс помощью метода CompleteAdding
        _blockingCollection.Add(4);
        _blockingCollection.Add(8);
        _blockingCollection.CompleteAdding();
        
        // Поток-потребитель потребляет значения
        // Потребитель не ожидает CompleteAdding
        foreach (var item in _blockingCollection.GetConsumingEnumerable())
        {
            Console.WriteLine(item);
        }
        
        // TODO: запустить производителя и потребителя в разных потоках
    }
}