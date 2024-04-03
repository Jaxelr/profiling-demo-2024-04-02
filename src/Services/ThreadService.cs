namespace ProfileableApi.Services;

public class ThreadService : IService
{
    private readonly object lock1 = new();
    private readonly object lock2 = new();

    public void Run()
    {
        var task1 = Task.Run(() =>
        {
            lock (lock1)
            {
                Thread.Sleep(100);
                lock (lock2) {}
            }
        });

        var task2 = Task.Run(() =>
        {
            lock (lock2)
            {
                Thread.Sleep(100);
                lock (lock1) {}
            }
        });

        Task.WaitAll(task1, task2);
    }
}
