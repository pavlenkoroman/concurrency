using System.Threading.Tasks.Dataflow;

namespace Concurrency.ChapterFive;

public class DataflowExceptionPropagation
{
    public async Task DefineExceptionDataflowLink()
    {
        try
        {
            var block = new TransformBlock<int, int>(item =>
            {
                if (item == 1)
                {
                    throw new InvalidOperationException("Мы не одобряем единицы");
                }

                return item * 2;
            });

            block.Post(1);
            block.Post(2);

            await block.Completion;
        }
        catch (InvalidOperationException e)
        {
            Console.WriteLine($"Было перехвачено исключение со следующим текстом: {e.Message}");
        }
    }

    public async Task DefineExceptionPropagatingWeb()
    {
        try
        {
            var multiplyBlock = new TransformBlock<int, int>(item =>
            {
                if (item == 1)
                {
                    throw new InvalidOperationException("Мы не одобряем единицы");
                }

                return item * 2;
            });

            var subtractBlock = new TransformBlock<int, int>(item => item - 2);

            multiplyBlock.LinkTo(subtractBlock, new DataflowLinkOptions { PropagateCompletion = true });

            multiplyBlock.Post(1);
            await subtractBlock.Completion;
        }
        catch (AggregateException e)
        {
            Console.WriteLine(e.Message);
        }
    }
}