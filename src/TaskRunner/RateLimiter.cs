using System.Collections.Concurrent;

namespace TaskRunner;

public class RateLimiter(int maxRequests, long windowSizeMs)
{
    private readonly ConcurrentDictionary<string, Queue<long>> _cache = new();
    
    public bool Allow(string userId, long timestampMs)
    {
        var queue = _cache.GetOrAdd(userId, static _ => new Queue<long>());

        lock (queue)
        {
            while (queue.Count > 0 && queue.Peek() < timestampMs - windowSizeMs)
            {
                queue.Dequeue();
            }

            if (queue.Count < maxRequests)
            {
                queue.Enqueue(timestampMs);
                return true;
            }

            return false;
        }
    }
}

