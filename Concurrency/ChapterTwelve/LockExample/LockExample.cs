namespace Concurrency.ChapterTwelve.LockExample;

public class LockExample
{
    private readonly object _lockObject = new object();
    private int _value;

    public void Increment()
    {
        // видимость блокировки ограничена: изменяется только одно приватное поле
        // блокировка защищает от совместного чтения/записи поля _value
        // код, защищённый блокировкой минимален
        // произвольного кода (выдача событий, вызова виртуальных методов, вызова делагатов) внутри лока нет
        lock (_lockObject)
        {
            _value += 1;
        }
    }
}