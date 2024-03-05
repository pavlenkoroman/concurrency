using System.Threading.Channels;

namespace Concurrency.ChapterNine.Channels;

public class ChannelExample
{
    public static void ExecuteChannelsExample()
    {
    }

    public async Task ExecuteProducer()
    {
        Channel<int> queue = Channel.CreateUnbounded<int>();

        ChannelWriter<int> writer = queue.Writer;
        await writer.WriteAsync(10);
        await writer.WriteAsync(110);
        writer.Complete();
    }

    public async Task ExecuteConsumer(Channel<int> queue)
    {
        ChannelReader<int> reader = queue.Reader;

        await foreach (var value in reader.ReadAllAsync())
        {
            Console.WriteLine(value);
        }
    }
}