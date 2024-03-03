namespace Concurrency.ChapterFour.ParallelLinq;

public class ParallelLinq
{
    // PLINQ параллельно обрабатывает коллекцию values, формируя новую коллекцию
    // Сохранение порядка элементов не гарантировано
    IEnumerable<int> Double(IEnumerable<int> values)
    {
        return values.AsParallel().Select(value => value * 2);
    }
    
    // PLINQ параллельно обрабатывает коллекцию values, формируя новую коллекцию
    // В данном случае сохранение порядка элементов гарантировано
    public IEnumerable<int> OrderedDouble(IEnumerable<int> values)
    {
        return values.AsParallel().AsOrdered().Select(value => value * 2);
    }

    // PLINQ параллельно аггрегирует элементы, в частности суммирует их
    public int ParallelSum(IEnumerable<int> values)
    {
        return values.AsParallel().Sum();
    }
}