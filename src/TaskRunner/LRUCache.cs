namespace TaskRunner;

public class LRUCache<TKey, TValue>
{
    private readonly int _capacity;
    
    private readonly Dictionary<TKey, LinkedListNode<(TKey Key, TValue Value)>> _cache = new();
    private readonly LinkedList<(TKey Key, TValue Value)> _nodes = new();

    public LRUCache(int capacity)
    {
        if(capacity <= 0) throw new ArgumentOutOfRangeException(nameof(capacity));
        _capacity = capacity;
    }

    public void Put(TKey key, TValue value)
    {

        if (_cache.TryGetValue(key, out var node))
        {
            _nodes.Remove(node);
        }
        else if (_cache.Count == _capacity)
        {
            _cache.Remove(_nodes.Last!.Value.Key);
            _nodes.RemoveLast();
        }
        
        var newNode = new LinkedListNode<(TKey, TValue)>((key, value));
        _cache[key] = newNode;
        _nodes.AddFirst(newNode);
    }

    public TValue? Get(TKey key)
    {
        var value = default(TValue);
        if(_cache.TryGetValue(key, out var node))
        {
            value = node.Value.Value;
            _nodes.Remove(node);
            _nodes.AddFirst(node);
        }
        
        return value;
    }
}