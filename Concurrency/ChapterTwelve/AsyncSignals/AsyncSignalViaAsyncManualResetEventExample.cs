using Nito.AsyncEx;

namespace Concurrency.ChapterTwelve.AsyncSignals;

public class AsyncSignalViaAsyncManualResetEventExample
{
    private readonly AsyncManualResetEvent _connected = new();

    public async Task WaitForConnectedAsync()
    {
        await _connected.WaitAsync();
    }

    public void ConnectedChanged(bool connected)
    {
        if (connected)
        {
            _connected.Set();
        }
        else
        {
            _connected.Reset();
        }
    }
}