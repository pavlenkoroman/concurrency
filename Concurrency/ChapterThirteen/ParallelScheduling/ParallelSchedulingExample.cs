using Concurrency.ChapterFour.ParallelDataProcessing;

namespace Concurrency.ChapterThirteen.ParallelScheduling;

public class ParallelSchedulingExample
{
    public void RotateMatrices(IEnumerable<IEnumerable<Matrix>> collections, double degrees)
    {
        var schedulersPair = new ConcurrentExclusiveSchedulerPair(TaskScheduler.Default, maxConcurrencyLevel: 8);
        var scheduler = schedulersPair.ConcurrentScheduler;

        var options = new ParallelOptions { TaskScheduler = scheduler };

        Parallel.ForEach(
            collections,
            options,
            matrices => Parallel.ForEach(matrices, options, matrix => matrix.Rotate(degrees)));
    }
}