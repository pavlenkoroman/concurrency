using System.Collections.Immutable;

namespace Concurrency.ChapterNine.ImmutableSets;

public static class ImmutableSetsExample
{
    public static void ExecuteSimpleImmutableHashSetExample()
    {
        var hashSet = ImmutableHashSet<int>.Empty;
        hashSet = hashSet.Add(1234934);
        var newHashSet = hashSet.Add(871234813);

        foreach (var item in newHashSet)
        {
            Console.WriteLine(item);
        }

        var removedElementHashSet = newHashSet.Remove(1234934);
    }
    
    public static void ExecuteSimpleImmutableSortedSetExample()
    {
        var sortedSet = ImmutableSortedSet<int>.Empty;
        sortedSet = sortedSet.Add(1234934);
        var newHashSet = sortedSet.Add(871234813);

        foreach (var item in newHashSet)
        {
            Console.WriteLine(item);
        }

        var smallestItem = sortedSet[0];
        Console.WriteLine(smallestItem);

        var removedElementHashSet = newHashSet.Remove(1234934);
    }
}