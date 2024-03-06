namespace Concurrency.ChapterEleven.AsyncProperties;

public class CachedAsyncValue<T>(T value)
{
    public T Value { get; private init; } = value;
}