namespace Concurrency.ChapterEleven.AsyncConstruction;

public interface IAsyncInitializable
{
    public Task Initialization { get; }
}