using System.Threading.Tasks.Dataflow;
using Concurrency.ChapterFive;
using Xunit;

namespace Concurrency.ChapterSeven.TestingDataflow;

public class CustomDataflowBlockTests
{
    [Fact]
    public async Task CustomDataflowBlock_MakesRightOperations()
    {
        var customDataflowBlock = new CustomDataflowBlock().CreateCustomBlock();
        
        customDataflowBlock.Post(3);
        customDataflowBlock.Post(17);
        customDataflowBlock.Complete();
        
        Assert.Equal(4, customDataflowBlock.Receive());
        Assert.Equal(18, customDataflowBlock.Receive());

        await customDataflowBlock.Completion;
    }

    [Fact]
    public async Task CustomDataflowBlock_Fault_DiscardsDataAndFaults()
    {
        var customDataflowBlock = new CustomDataflowBlock().CreateCustomBlock();
        
        customDataflowBlock.Post(3);
        customDataflowBlock.Post(13);
        
        customDataflowBlock.Fault(new InvalidOperationException());

        try
        {
            await customDataflowBlock.Completion;
        }
        catch (AggregateException e)
        {
            AssertExceptionIs<InvalidOperationException>(e.Flatten().InnerException!, false);
        }
    }

    private static void AssertExceptionIs<TException>(Exception ex, bool allowDerivedTypes = true)
    {
        if (allowDerivedTypes && !(ex is TException))
        {
            Assert.Fail($"Exception is of type {ex.GetType().Name}, " +
                        $"but {typeof(TException).Name} or a derived type was expected");
        }

        if (!allowDerivedTypes && ex.GetType() != typeof(TException))
        {
            Assert.Fail($"Exception is of type {ex.GetType().Name}, but {typeof(TException).Name} was expected");
        }
    }
}