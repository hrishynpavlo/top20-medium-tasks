namespace TaskRunner;

public class KthLargest
{
    private readonly int _k;
    private readonly PriorityQueue<int, int> _minHeap = new();
    
    public KthLargest(int k, int[] nums) 
    {
        if(k <= 0) throw new ArgumentOutOfRangeException(nameof(k), "k must be greater than 0");
        
        _k = k;

        foreach (var val in nums)
        {
            AddToHeap(val);
        }
    }
    
    public int Add(int val)
    {
        AddToHeap(val);
        return _minHeap.Peek();
    }

    private void AddToHeap(int val)
    {
        if (_minHeap.Count < _k)
        {
            _minHeap.Enqueue(val, val);
        }
        else if(_minHeap.Peek() < val)
        {
            _minHeap.EnqueueDequeue(val, val);
        }
    }
}