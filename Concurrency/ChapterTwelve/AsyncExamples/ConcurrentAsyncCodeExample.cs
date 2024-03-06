namespace Concurrency.ChapterTwelve.AsyncExamples;

public class ConcurrentAsyncCodeExample
{
    private int _value;

    public async Task ModifyValueAsync()
    {
        await Task.Delay(TimeSpan.FromSeconds(1));
        _value += 1;
    }

    // Надобность в синхронизации зависит от контекста, в котором выполняется поток
    // Если поток выполняется в GUI контексте, где существует только UI-поток, который и будет выполнять каждое изменение, то они не смогут происходить одновременно
    // Если этот метод будет выполняться в потоках из пула, то синхронизация понадобится, ибо несколько потоков из пула смогут одновременно читать и изменять переменную 
    public async Task<int> ModifyValueConcurrentlyAsync()
    {
        var task1 = ModifyValueAsync();
        var task2 = ModifyValueAsync();
        var task3 = ModifyValueAsync();

        await Task.WhenAll(task1, task2, task3);

        return _value;
        
    }
}