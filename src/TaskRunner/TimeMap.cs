namespace TaskRunner;

public class TimeMap<TKey, TValue> where TKey : notnull
{
    private readonly Dictionary<TKey, List<(TValue Value, int Timestamp)>> _cache = new();
    
    public void Set(TKey key, TValue value, int timestamp)
    {
        if (!_cache.TryGetValue(key, out var binaryTree))
        {
            binaryTree = new List<(TValue Value, int Timestamp)>();
            _cache.Add(key, binaryTree);
        }
        
        binaryTree.Add((value, timestamp));
    }

    public TValue? Get(TKey key, int timestamp)
    {
        if (!_cache.TryGetValue(key, out var binaryTree))
            return default;

        return BinarySearchUpperBound(binaryTree, timestamp);
    }
    
    private TValue? BinarySearchUpperBound(List<(TValue Value, int Timestamp)> binaryTree, int timestamp)
    {
        TValue? result = default;
        
        if (binaryTree.Count == 0) return result!;
        if(binaryTree.Count == 1) return binaryTree[0].Timestamp <= timestamp ? binaryTree[0].Value : result;
        
        int left = 0, right = binaryTree.Count - 1;
        while (left <= right)
        {
            var mid = left + (right - left) / 2;
            if (binaryTree[mid].Timestamp <= timestamp)
            {
                result = binaryTree[mid].Value;
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
