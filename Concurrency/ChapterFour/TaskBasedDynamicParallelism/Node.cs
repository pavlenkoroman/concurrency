namespace Concurrency.ChapterFour.TaskBasedDynamicParallelism;

public class Node<T>(Node<T>? left, Node<T>? right, T value)
{
    public Node<T>? Left { get; set; } = left;
    public Node<T>? Right { get; set; } = right;
    public T Value { get; set; } = value;
}