using System.Collections.Concurrent;

namespace ProfileableApi.Services;

public class MemoryService : IService
{
    private readonly ConcurrentDictionary<Guid, object> cache = new();
    private readonly string chars = new('x', 25);
    private readonly int messageSize = 32_000;

    public void Run() => cache.GetOrAdd(Guid.NewGuid(), Value);

    private object Value
    {
        get
        {
            var random = new Random();
            string result = new(Enumerable.Repeat(chars, messageSize)
                .Select(s => s[random.Next(s.Length)]).ToArray());

            return result;
        }
    }
}
