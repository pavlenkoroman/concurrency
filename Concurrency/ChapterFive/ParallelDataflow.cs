using System.Threading.Tasks.Dataflow;

namespace Concurrency.ChapterFive;

public class ParallelDataflow
{
    public void DefineParallelDataflow()
    {
        var multiplyBlock = new TransformBlock<int, int>(
            item => item * 2,
            new ExecutionDataflowBlockOptions
            {
                MaxDegreeOfParallelism = DataflowBlockOptions.Unbounded
            });

        var subtractBlock = new TransformBlock<int, int>(item => item - 2);

        multiplyBlock.LinkTo(subtractBlock);
    }
}