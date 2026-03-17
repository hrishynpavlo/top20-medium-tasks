namespace TaskRunner;

public class LRUCache<TKey, TValue>
{
    private readonly int _capacity;
    
    private readonly Dictionary<TKey, LinkedListNode<(TKey Key, TValue Value)>> _cache = new();
    private readonly LinkedList<(TKey Key, TValue Value)> _node = new();

    public LRUCache(int capacity)
    {
        if(capacity <= 0) throw new ArgumentOutOfRangeException(nameof(capacity));
        _capacity = capacity;
    }
    
    public void Put(TKey key, TValue value)
    {
        // TODO: handle update
        
        var last = _node.Last;
        var newNode = new  LinkedListNode<(TKey, TValue)>((key, value));
        
        if (_cache.Count == _capacity)
        {
            _cache.Remove(last!.Value.Key);
        }
        
        _node.AddFirst(newNode);
        _node.Remove(last!);
        _cache[key] = newNode;
    }
    
    public TValue? Get(TKey key)
    {
        var value = default(TValue);
        if(_cache.TryGetValue(key, out var node))
        {
            value = node.Value.Value;
            _node.Remove(node);
            _node.AddFirst(node);
        }
        
        return value;
    }
}