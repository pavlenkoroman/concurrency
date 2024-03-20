using System.Threading.Tasks.Dataflow;

namespace Concurrency.ChapterThirteen.DataflowScheduling;

public class DataflowSchedulingExample
{
    public List<int> ListBox { get; } = new List<int>();

    public void Example()
    {
        var options = new ExecutionDataflowBlockOptions
        {
            TaskScheduler = TaskScheduler.FromCurrentSynchronizationContext()
        };
        var multiplyBlock = new TransformBlock<int, int>(a => a * 2);
        var displayBlock = new ActionBlock<int>(result => ListBox.Add(result), options);
        multiplyBlock.LinkTo(displayBlock);
    }
}