namespace Concurrency.ChapterFour.TaskBasedDynamicParallelism;

public class TasksContinuation
{
    public void ExecuteContinuationTasksExample()
    {
        // Запускаем первую задачу
        var task = Task.Factory.StartNew(
            () => Thread.Sleep(TimeSpan.FromSeconds(2)),
            CancellationToken.None,
            TaskCreationOptions.None,
            TaskScheduler.Default);

        // Вторая задача запустится после окончания первой
        var continuation = task.ContinueWith(
            t => Console.WriteLine("Task is done"),
            CancellationToken.None,
            TaskContinuationOptions.None,
            TaskScheduler.Default);
        
        // В StartNew и ContinueWith рекомендуется указывать TaskScheduler
    }
}