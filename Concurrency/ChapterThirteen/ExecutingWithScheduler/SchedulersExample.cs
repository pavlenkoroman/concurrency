namespace Concurrency.ChapterThirteen.ExecutingWithScheduler;

public class SchedulersExample
{
    public void Execute()
    {
        // планировщик задач, сохраняющий текущий контекст синхронизации для продолжения работы в нём
        var scheduler = TaskScheduler.FromCurrentSynchronizationContext();
        
        // пара планировщиков. Компонент ConcurrentScheduler позволяет выполняться нескольким задачам одновременно
        // при условии, что ни одна задача не выполняется в ExclusiveScheduler
        // задачи в ExclusiveScheduler выполняются по одной при условии, что ConcurrentScheduler не выполняет задачи
        var schedulersPair = new ConcurrentExclusiveSchedulerPair();
        var concurrent = schedulersPair.ConcurrentScheduler;
        
        // код выполняется потоком из пула
        var exclusive = schedulersPair.ExclusiveScheduler;
    }

    public void ExecuteRegulatedSchedulersPair()
    {
        var schedulersPair = new ConcurrentExclusiveSchedulerPair(TaskScheduler.Default, maxConcurrencyLevel: 52);
        
        // уровень параллелизма ограничен, код будет выполняться в потоке из пула
        var concurrent = schedulersPair.ConcurrentScheduler;
    }
}