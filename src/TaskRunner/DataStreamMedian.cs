namespace TaskRunner;

public class DataStreamMedian
{
    // First item is the smallest in the upper half
    private readonly BinaryHeap _minBucket = new (true);
    
    // First item is the biggest in the lower half
    private readonly BinaryHeap _maxBucket = new (false);

    public void AddNum(int num)
    {
        if (_maxBucket.Length == 0 || num <= _maxBucket.Peek())
        {
            _maxBucket.Add(num);
        }
        else
        {
            _minBucket.Add(num);
        }

        if(_maxBucket.Length > _minBucket.Length + 1)
        {
            _minBucket.Add(_maxBucket.Extract());
        }
        else  if (_minBucket.Length > _maxBucket.Length + 1)
        {
            _maxBucket.Add(_minBucket.Extract());
        }
    }

    public double FindMedian()
    {
        return (_minBucket.Length, _maxBucket.Length) switch
        {
            (0, 0) => 0,
            (0, _) => _maxBucket.Peek(),
            (_, 0) => _minBucket.Peek(),
            _ when _minBucket.Length == _maxBucket.Length => (_maxBucket.Peek() + _minBucket.Peek()) / 2d,
            _ when _minBucket.Length > _maxBucket.Length => _minBucket.Peek(),
            _ => _maxBucket.Peek()
        };
    }
}

public class BinaryHeap(bool isMinHeap)
{
    private readonly List<int> _heap = new();

    public void Add(int num)
    {
        _heap.Add(num);
        var index = _heap.Count - 1;
        var parentIndex = (index - 1) / 2;

        HeapifyUp(index, parentIndex);
    }

    public int Peek()
    {
        return _heap[0];
    }

    public int Extract()
    {
        var result = _heap[0];

        var index = _heap.Count - 1;
        _heap[0] = _heap[index];
        _heap.RemoveAt(index);

        HeapifyDown();

        return result;
    }

    public int Length => _heap.Count;

    private void HeapifyUp(int index, int parentIndex)
    {
        while (index > 0 && 
               ((isMinHeap && _heap[index] < _heap[parentIndex]) ||
                (!isMinHeap && _heap[index] > _heap[parentIndex])))
        {
            // swap
            (_heap[parentIndex], _heap[index]) = (_heap[index], _heap[parentIndex]);

            // move up
            index = parentIndex;
            parentIndex = (index - 1) / 2;
        }
    }

    private void HeapifyDown()
    {
        int index = 0, left = 1, right = 2;

        while (left < _heap.Count)
        {
            int target;
            if (right < _heap.Count)
            {
                target = isMinHeap
                    ? (_heap[left] < _heap[right] ? left : right)
                    : (_heap[left] > _heap[right] ? left : right);
            }
            else
            {
                target = left;
            }

            if ((isMinHeap && _heap[index] > _heap[target]) ||
                (!isMinHeap && _heap[index] < _heap[target]))
            {
                (_heap[index], _heap[target]) = (_heap[target], _heap[index]);
                
                index = target;
                left = index * 2 + 1;
                right = index * 2 + 2;
            }
            else
            {
                break;
            }
        }
    }
}