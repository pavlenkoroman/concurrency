namespace Concurrency.ChapterFour.TaskBasedDynamicParallelism;

public class BinaryTreeParallelProcessing
{
    public void ProcessTree(Node<double> root)
    {
        var task = Task.Factory.StartNew(
            () => Traverse(root),
            CancellationToken.None,
            TaskCreationOptions.None,
            TaskScheduler.Default);

        task.Wait();
    }

    private void Traverse(Node<double> currentNode)
    {
        // Производим "дорогую" операцию над нодой дерева
        DoExpensiveActionOnNode(currentNode);
        
        // Если существует левая нода, то создаём новый таск и запускаем
        if (currentNode.Left is not null)
        {
            // action - делегат, выполняемый таском
            // Cancellation token отсутствует, поэтому нет возможности отменить выполнение таска
            // Attached to parent - задача-родитель после переданного выполнения делегата будет ожидать выполнения дочерних задач (запущенных делегатом, выполняющий метод Traverse)
            // Исключения распространяются от дочерних к родительской задаче
            Task.Factory.StartNew(
                () => Traverse(currentNode.Left),
                CancellationToken.None,
                TaskCreationOptions.AttachedToParent,
                TaskScheduler.Default);
        }

        if (currentNode.Right is not null)
        {
            Task.Factory.StartNew(
                () => Traverse(currentNode.Right),
                CancellationToken.None,
                TaskCreationOptions.AttachedToParent,
                TaskScheduler.Default);
        }
    }

    private void DoExpensiveActionOnNode(Node<double> current)
    {
        // Симуляция "дорогостоящих" действий над нодой дерева
        for (var i = 0; i < 1000000; i++)
        {
            current.Value = PerformComplexCalculation(current.Value);
        }
    }

    private double PerformComplexCalculation(double input)
    {
        dynamic numericValue = Convert.ChangeType(input, typeof(double));
        numericValue *= 2;

        return (double)numericValue;
    }
}