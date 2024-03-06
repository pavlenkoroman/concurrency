namespace Concurrency.ChapterTwelve.SyncSignals;

public class ManualResetEventSlimExample
{
    private readonly ManualResetEventSlim _initialized = new ManualResetEventSlim();
    private int _value;

    public int WaitForInitialization()
    {
        _initialized.Wait();
        return _value;
    }

    public void InitializaFromAnotherThread()
    {
        _value = 13;
        _initialized.Set();
    }
}