namespace Concurrency.ChapterThirteen.SchedulingInThreadPool;

public class ThreadPoolExample
{
    public void ExecuteExample()
    {
        // Берёт поток из пула для выполнения лямбда-функции
        // TaskScheduler = default (таск выполняется в потоке из пула)
        var task = Task.Run(() =>
        {
            // Блокирует поток из пула на 5 секунд
            Thread.Sleep(5000);
        });
    }

    public void ExecuteExampleAsync()
    {
        Task.Run(async () =>
        {
            await Task.Delay(TimeSpan.FromSeconds(5));
            return 52;
        });
    }
}