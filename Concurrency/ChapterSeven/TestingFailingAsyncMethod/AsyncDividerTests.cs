using Xunit;

namespace Concurrency.ChapterSeven.TestingFailingAsyncMethod;

public class AsyncDividerTests
{
    [Fact]
    public async Task DivideAsync_WhenDenominatorIsZero_ShouldThrow_DivideByZeroException()
    {
        var divider = new AsyncDivider();
        await Assert.ThrowsAsync<DivideByZeroException>(() => divider.DivideAsync(5, 0));
    }
    
    [Fact]
    public async Task MakeChoiceAsync_Should_ReturnFalse_WithCustomAssert()
    {
        var divider = new AsyncDivider();
        var result =
            await ThrowsAsyncAnalog.ThrowsAsync<DivideByZeroException>(() => divider.DivideAsync(9, 0));

        Assert.NotNull(result);
    }
}