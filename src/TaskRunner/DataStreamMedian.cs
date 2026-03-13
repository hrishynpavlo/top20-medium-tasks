namespace TaskRunner;

public class DataStreamMedian
{
    private readonly BinaryHeap _minBucket = new (true);
    private readonly BinaryHeap _maxBucket = new (false);

    public void AddNum(int num)
    {
        var median = FindMedian();
        if (num < median)
        {
            _minBucket.Add(num);
        }
        else
        {
            _maxBucket.Add(num);
        }

        if (_minBucket.Lenght > _maxBucket.Lenght + 1)
        {
            _maxBucket.Add(_minBucket.Extract());
        }

        if(_maxBucket.Lenght > _minBucket.Lenght + 1)
        {
            _minBucket.Add(_maxBucket.Extract());
        }
    }

    public double FindMedian()
    {
        return (_minBucket.Lenght, _maxBucket.Lenght) switch
        {
            (0, 0) => 0,
            (0, _) => _maxBucket.Peek(),
            (_, 0) => _minBucket.Peek(),
            _ when _minBucket.Lenght == _maxBucket.Lenght => (_maxBucket.Peek() + _minBucket.Peek()) / 2d,
            _ when _minBucket.Lenght > _maxBucket.Lenght => _minBucket.Peek(),
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

        MoveUpAndSwap(index, parentIndex);
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

        index = _heap.Count - 1;
        var parentIndex = (index - 1) / 2;

        MoveUpAndSwap(index, parentIndex);

        return result;
    }

    public int Lenght => _heap.Count;

    private void MoveUpAndSwap(int index, int parentIndex)
    {
        while ((isMinHeap && _heap[index] > _heap[parentIndex])
               || (!isMinHeap && _heap[index] < _heap[parentIndex]))
        {
            // swap
            (_heap[parentIndex], _heap[index]) = (_heap[index], _heap[parentIndex]);

            // move up
            index = parentIndex;
            parentIndex = (index - 1) / 2;
        }
    }
}