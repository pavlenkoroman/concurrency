using Concurrency.ChapterSeven.TestingFailingAsyncMethod;
using Xunit;

namespace Concurrency.ChapterSeven.TestingAsyncMethod;

public class AsyncChoiceMakerTests
{
    [Fact]
    public async Task MakeChoiceAsync_Should_ReturnFalse()
    {
        var choiceMaker = new AsyncChoiceMaker();
        var result = await choiceMaker.MakeChoiceAsync();
        Assert.False(result);
    }
}