using System.Threading.Tasks.Dataflow;

namespace Concurrency.ChapterFive;

public class DataflowThrottling
{
    public void DefineConditionalBlockDataflow()
    {
        var sourceBlock = new BufferBlock<int>();
        var options = new DataflowBlockOptions { BoundedCapacity = 1 };
        var targetBlockA = new BufferBlock<int>();
        var targetBlockB = new BufferBlock<int>();

        sourceBlock.LinkTo(targetBlockA);
        sourceBlock.LinkTo(targetBlockB);
    }
}