using System.Threading.Tasks.Dataflow;

namespace Concurrency.ChapterFive;

public class Dataflow
{
    public async Task DefineDataflow()
    {
        // Объявление блоков умножения и вычитания
        var multiplyBlock = new TransformBlock<int, int>(item => item * 2);
        var subtractBlock = new TransformBlock<int, int>(item => item - 2);

        // Объявление опций для связи блоков. PropagateCompletion отвечает за распространение завершения между блоками
        var options = new DataflowLinkOptions { PropagateCompletion = true };
        
        // Объявление связи от блока умножения до блока вычитания. Данные из блока умножения попадают в блок вычитания.
        multiplyBlock.LinkTo(subtractBlock, options);

        multiplyBlock.Complete();
        await subtractBlock.Completion;
    }
}