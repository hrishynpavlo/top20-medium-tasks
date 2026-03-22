namespace TaskRunner;

public class AllOne
{
    // Main cache (key and counter)
    private readonly Dictionary<string, int> _cache = new();

    // Indexed by count 
    private readonly Dictionary<int, LinkedListNode<(int Count, HashSet<string> Keys)>> _index = new();
    
    // Main node
    private readonly LinkedList<(int Count,HashSet<string> Keys)> _nodes = new();

    public void Inc(string key)
    {
        // update actual cache
        var count = _cache.GetValueOrDefault(key, 0);
        _cache[key] = count + 1;

        // get or update new node
        // max count in the node beginning, that's why we insert in the tail, or before previous
        var prevNodeExists = _index.TryGetValue(count, out var prevNode);
        if (!_index.TryGetValue(count + 1, out var newNode))
        {
            if (prevNodeExists)
            {
                _nodes.AddBefore(prevNode!, (count + 1, []));
                newNode = prevNode!.Previous!;
            }
            else
            {
                _nodes.AddLast((count + 1, []));
                newNode = _nodes.Last!;
            }
            
            _index[count + 1] = newNode;
        }

        // remove key from previous count, and clean cache if necessary
        if (prevNodeExists && prevNode!.Value.Keys.Remove(key) && prevNode.Value.Keys.Count == 0)
        {
            _index.Remove(count);
            _nodes.Remove(prevNode);
        }

        newNode.Value.Keys.Add(key);
    }
    
    public void Dec(string key)
    {
        var count = _cache[key];

        // Eviction
        var isEviction = count == 1;
        if (isEviction)
        {
            _cache.Remove(key);
        }
        else
        {
            _cache[key] = count - 1;
        }
        
        var currentNode = _index[count];
        if (!isEviction)
        {
            if (!_index.TryGetValue(count - 1, out var newNode))
            {
                _nodes.AddAfter(currentNode, (count - 1, []));
                newNode = currentNode.Next!;
                _index[count - 1] = newNode;
            }

            newNode.Value.Keys.Add(key);
        }
        
        currentNode.Value.Keys.Remove(key);
        if (currentNode.Value.Keys.Count == 0)
        {
            _index.Remove(count);
            _nodes.Remove(currentNode);
        }
    }
    
    public string GetMaxKey()
    {
        return _nodes.First?.Value.Keys.FirstOrDefault()  ?? "";
    }
    
    public string GetMinKey()
    {
        return _nodes.Last?.Value.Keys.FirstOrDefault() ?? "";
    }
}