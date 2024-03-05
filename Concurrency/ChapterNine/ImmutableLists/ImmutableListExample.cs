using System.Collections.Immutable;

namespace Concurrency.ChapterNine.ImmutableLists;

public static class ImmutableListExample
{
    public static void ExecuteImmutableListExample()
    {
        var list = ImmutableList<int>.Empty;
        list = list.Insert(0, 10);
        list = list.Insert(0, 100);

        // 100 10
        foreach (var item in list)
        {
            Console.WriteLine(item);
        }

        list = list.RemoveAt(1);
    }
}