namespace Concurrency.ChapterTwelve.AsyncExamples;

public class SimpleAsyncExample
{
    public async Task MakeAsync()
    {
        // Строки кода, обращающиеся к значениям могут выполняться в разных потоках из пула
        // Нет надобности в синхронизации, ибо метод не сможет выполняться одновременно в нескольких потоках из пула
        int value = 10;
        await Task.Delay(1000);
        value += 1;
        await Task.Delay(1000);
        value -= 1;
        await Task.Delay(1000);
        Console.WriteLine(value);
    }
}