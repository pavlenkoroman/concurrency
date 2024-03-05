using System.Collections.Immutable;

namespace Concurrency.ChapterNine.ImmutableStacksAndQueues;

public static class ImmutableStackExample
{
    public static void ExecuteSimpleImmutableStackExample()
    {
        var stack = ImmutableStack<int>.Empty;
        stack = stack.Push(10);
        stack = stack.Push(20);

        foreach (var item in stack)
        {
            Console.WriteLine(item);
        }

        stack = stack.Pop(out var lastItem);
        Console.WriteLine(lastItem);
    }

    public static void ExecuteSharedMemoryStacksExample()
    {
        var stack = ImmutableStack<int>.Empty;
        stack = stack.Push(50);
        var anotherStack = stack.Push(100);
        
        // stack и anotherStack совместно используют память для элемента 50

        foreach (var item in stack)
        {
            Console.WriteLine(item);
        }

        foreach (var item in anotherStack)
        {
            Console.WriteLine(item);
        }
    }
}