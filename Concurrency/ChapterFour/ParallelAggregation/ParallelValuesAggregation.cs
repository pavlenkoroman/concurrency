namespace Concurrency.ChapterFour.ParallelAggregation;

public class ParallelValuesAggregation
{
    // Параллельное аггрегировние всех значений из перечисления values
    public int ParallelSum(IEnumerable<int> values)
    {
        var lockObject = new object();
        var result = 0;
        
        // source - источник значений (коллекция, с которой мы работаем)
        // localInit - локальная переменная, для доступа к которой циклу нет необходимости в синхронизации
        // body - тело цикла, основное выполняемое действие
        // localFinally - делегат, выполняющий аггрегирование локальных результатов, когда цикл готов
        Parallel.ForEach(
            source: values,
            localInit: () => 0,
            body: (item, state, localValue) => localValue + item,
            localFinally: localValue =>
            {
                lock (lockObject)
                {
                    result += localValue;
                }
            });

        return result;
    }

    // Параллельное вычисление суммы с помощью PLINQ
    public int ParallelSumPlinq(IEnumerable<int> values)
    {
        return values.AsParallel().Sum();
    }

    public int ParallelAggregationPlinq(IEnumerable<int> values)
    {
        // seed - начальное значение
        // func - функция, применяющаяся к каждому элементу перечисления
        return values.AsParallel().Aggregate(
            seed: 0,
            func: (sum, item) => sum + item);
    }
}