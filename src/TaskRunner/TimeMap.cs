namespace TaskRunner;

public class TimeMap<TKey, TValue> where TKey : notnull
{
    private readonly Dictionary<TKey, List<(TValue Value, int Timestamp)>> _cache = new();
    
    /// <summary>
    /// Stores the value value for the given key at the specified timestamp. It is guaranteed that the timestamp for the same key is strictly increasing.
    /// </summary>
    public void Set(TKey key, TValue value, int timestamp)
    {
        if (!_cache.TryGetValue(key, out var sortedRecords))
        {
            sortedRecords = new List<(TValue Value, int Timestamp)>();
            _cache.Add(key, sortedRecords);
        }
        
        sortedRecords.Add((value, timestamp));
    }

    /// <summary>
    /// Returns the value associated with key whose timestamp is less than or equal to the given timestamp and is the largest possible.
    /// </summary>
    public TValue? Get(TKey key, int timestamp)
    {
        if (!_cache.TryGetValue(key, out var sortedRecords))
            return default;

        return BinarySearchFloor(sortedRecords, timestamp);
    }
    
    private TValue? BinarySearchFloor(List<(TValue Value, int Timestamp)> sortedRecords, int timestamp)
    {
        TValue? result = default;
        
        int left = 0, right = sortedRecords.Count - 1;
        while (left <= right)
        {
            var mid = left + (right - left) / 2;
            if (sortedRecords[mid].Timestamp <= timestamp)
            {
                result = sortedRecords[mid].Value;
                left = mid + 1;
            }
            else
            {
                right = mid - 1;
            }
        }

        return result;
    }
}
