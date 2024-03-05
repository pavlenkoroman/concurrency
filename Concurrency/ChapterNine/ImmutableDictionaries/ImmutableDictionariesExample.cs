using System.Collections.Immutable;

namespace Concurrency.ChapterNine.ImmutableDictionaries;

public static class ImmutableDictionariesExample
{
    public static void ExecuteImmutableDictionariesExample()
    {
        var dictionary = ImmutableDictionary<int, string>.Empty;
        dictionary = dictionary.Add(10, "sdfnsadfjsaf");
        dictionary = dictionary.Add(1, "sasfsaddfnsadfjsaf");
        dictionary = dictionary.Add(0, "sdsghffgdffnsadfjsaf");
        
        
        dictionary = dictionary.SetItem(1000, "gfhmnfgnnhfgsdfnsadfjsaf");

        // Элементы выведутся в непредсказуемом порядке
        foreach (var item in dictionary)
        {
            Console.WriteLine($"{item.Key} - {item.Value}");
        }
        
        Console.WriteLine(dictionary[0]);

        dictionary = dictionary.Remove(1000);
    }
    
    public static void ExecuteImmutableSortedDictionariesExample()
    {
        var sortedDictionary = ImmutableSortedDictionary<int, string>.Empty;
        sortedDictionary = sortedDictionary.Add(10, "sdfnsadfjsaf");
        sortedDictionary = sortedDictionary.Add(1, "sasfsaddfnsadfjsaf");
        sortedDictionary = sortedDictionary.Add(0, "sdsghffgdffnsadfjsaf");
        
        
        sortedDictionary = sortedDictionary.SetItem(1000, "gfhmnfgnnhfgsdfnsadfjsaf");

        // Элементы выведутся в отсортированном виде
        foreach (var item in sortedDictionary)
        {
            Console.WriteLine($"{item.Key} - {item.Value}");
        }
        
        Console.WriteLine(sortedDictionary[0]);

        sortedDictionary = sortedDictionary.Remove(1000);
    }
}