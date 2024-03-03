namespace Concurrency.ChapterFour.ParallelInvokation;

public class ParallelArrayProcessing
{
    private void ProcessPartialArray(double[] array, int begin, int end)
    {
        if (begin < 0 || end >= array.Length || begin > end)
        {
            throw new ArgumentException("Invalid begin or end index");
        }

        var middle = (begin + end) / 2;

        // Интенсивное использование процессора
        for (var i = begin; i <= middle; i++)
        {
            array[i] = Math.Pow(array[i], 2) + Math.Sqrt(array[i]);
        }

        for (var i = middle + 1; i <= end; i++)
        {
            array[i] = Math.Sin(array[i]) + Math.Cos(array[i]);
        }
    }

    // Параллельный вызов двух делегатов, обрабатывающие две части массива независимо друг от друга
    public void ProcessArray(double[] array)
    {
        Parallel.Invoke(
            () => ProcessPartialArray(array, 0, array.Length / 2),
            () => ProcessPartialArray(array, array.Length / 2, array.Length));
    }

    // Параллельный вызов делегата action 20 раз
    public void DoActionTwentyTimesParallel(Action action)
    {
        var actions = Enumerable.Repeat(action, 20).ToArray();
        Parallel.Invoke(actions);
    }
    
    // Параллельный вызов делегата action 20 раз с поддержкой отмены с использованием CancellationToken
    public void DoActionTwentyTimesParallel(Action action, CancellationToken cancellationToken)
    {
        var actions = Enumerable.Repeat(action, 20).ToArray();
        Parallel.Invoke(new ParallelOptions { CancellationToken = cancellationToken }, actions);
    }
}