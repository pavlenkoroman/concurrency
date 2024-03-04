using Xunit;

namespace Concurrency.ChapterSeven.TestingFailingAsyncMethod;

public static class ThrowsAsyncAnalog
{
    /// <summary>
    /// Гарантирует, что асинхронный делегат выдаст исключение
    /// </summary>
    /// <param name="action">Тестируемый делегат</param>
    /// <param name="allowDerivedTypes">Принимаются ли производные от TException</param>
    /// <typeparam name="TException">Тип эксепшена</typeparam>
    /// <returns></returns>
    public static async Task<TException> ThrowsAsync<TException>(Func<Task> action, bool allowDerivedTypes = true)
    where TException : Exception
    {
        try
        {
            await action();
            Assert.Fail($"Delegate did not throw excepted exception {nameof(Exception)}");
            return null;
        }
        catch (Exception e)
        {
            if (allowDerivedTypes && e is not TException)
            {
                Assert.Fail($"Delegate threw exception of type {e.GetType().Name}, " +
                            $"but {typeof(TException).Name} or a derived type was expected");
            }

            if (!allowDerivedTypes && e.GetType() != typeof(TException))
            {
                Assert.Fail($"Delegate threw exception of type {e.GetType().Name}, " +
                            $"but {typeof(TException).Name} was expected");
            }

            return (TException)e;
        }
    }
}