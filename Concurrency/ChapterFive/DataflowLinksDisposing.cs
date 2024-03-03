using System.Threading.Tasks.Dataflow;

namespace Concurrency.ChapterFive;

public class DataflowLinksDisposing
{
    public void DefineDataflowWithDisposingLink()
    {
        var multiplyBlock = new TransformBlock<int, int>(item => item * 2);
        var subtractBlock = new TransformBlock<int, int>(item => item - 2);
        var link = multiplyBlock.LinkTo(subtractBlock);
        multiplyBlock.Post(1);
        multiplyBlock.Post(2);
        
        link.Dispose();
    }
}