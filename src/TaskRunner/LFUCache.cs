namespace TaskRunner;

public class LFUCache
{
    private readonly int _capacity;
    
    // stores key + frequency
    private readonly Dictionary<int, (int Frequency, int Value, LinkedListNode<int> KeyNode)> _cache = new();
    
    // stores frequency + associated keys (sorted by recently used)
    private readonly Dictionary<int, LinkedList<int>> _frequencies = new();
    
    // stores minimal frequency
    private int _minimumFrequency = 1;
    
    public LFUCache(int capacity) 
    {
        if(capacity <= 0) throw new ArgumentOutOfRangeException(nameof(capacity), "Capacity must be greater than zero.");
        
        _capacity = capacity;
    }
    
    public int Get(int key)
    {
        if (!_cache.TryGetValue(key, out var element))
            return -1;

        // drop from old frequency bucket
        DropOldFrequency(element.KeyNode, element.Frequency);
        
        // update frequency for current key
        var newNode = SetNewFrequency(key, element.Frequency + 1);
        _cache[key] = (element.Frequency + 1, element.Value, newNode);

        return element.Value;
    }
    
    public void Put(int key, int value)
    {
        var frequency = 1;
        
        // Update case
        if (_cache.TryGetValue(key, out var element))
        {
            // remove from old frequency bucket
            DropOldFrequency(element.KeyNode, element.Frequency);

            // add frequency + 1 bucket
            frequency = element.Frequency + 1;
        }
        // Eviction
        else if (_cache.Count == _capacity)
        {
            var keyNode = _frequencies[_minimumFrequency].Last!;
            DropOldFrequency(keyNode, _minimumFrequency);
            
            _cache.Remove(keyNode.Value);
        }
        
        // create
        var newNode = SetNewFrequency(key, frequency);
        _cache[key] = (frequency, value, newNode);
    }

    private LinkedListNode<int> SetNewFrequency(int key, int frequency)
    {
        if (!_frequencies.TryGetValue(frequency, out var keysFrequencies))
        {
            keysFrequencies = new LinkedList<int>();
            _frequencies[frequency] = keysFrequencies;
        }

        keysFrequencies.AddFirst(key);

        if(frequency < _minimumFrequency)
        {
            _minimumFrequency = frequency;
        }
        
        return keysFrequencies.First!;
    }

    private void DropOldFrequency(LinkedListNode<int> keyNode, int frequency)
    {
        var frequenciesBucket = _frequencies[frequency];
        frequenciesBucket.Remove(keyNode);

        if(frequenciesBucket.Count == 0) _frequencies.Remove(frequency);
        
        if(frequenciesBucket.Count == 0 && _minimumFrequency == frequency)
        {
            _minimumFrequency = frequency + 1;
        }
    }
}