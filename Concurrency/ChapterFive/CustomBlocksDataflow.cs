using System.Threading.Tasks.Dataflow;

namespace Concurrency.ChapterFive;

public class CustomBlocksDataflow
{
    public IPropagatorBlock<int, int> CreateCustomBlock()
    {
        var multiplyBlock = new TransformBlock<int, int>(item => item * 2);
        var addBlock = new TransformBlock<int, int>(item => item + 2);
        var divideBlock = new TransformBlock<int, int>(item => item / 2);

        var dataflowCompletion = new DataflowLinkOptions { PropagateCompletion = true };

        multiplyBlock.LinkTo(addBlock, dataflowCompletion);
        addBlock.LinkTo(divideBlock, dataflowCompletion);

        return DataflowBlock.Encapsulate(multiplyBlock, divideBlock);
    }
}