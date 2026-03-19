namespace TaskRunner;

public class DataStreamMedian
{
    private readonly PriorityQueue<int, int> _minHeap = new();
    private readonly PriorityQueue<int, int> _maxHeap = new();

    public void AddNum(int num)
    {
        if (_maxHeap.Count == 0 || num <= _maxHeap.Peek())
        {
            _maxHeap.Enqueue(num, -1 * num);
        }
        else
        {
            _minHeap.Enqueue(num, num);
        }

        if(_maxHeap.Count > _minHeap.Count + 1)
        {
            var em = _maxHeap.Dequeue();
            _minHeap.Enqueue(em, em);
        }
        else  if (_minHeap.Count > _maxHeap.Count + 1)
        {
            var em = _minHeap.Dequeue();
            _maxHeap.Enqueue(em, -1 * em);
        }
    }

    public double FindMedian()
    {
        return (_minHeap.Count, _maxHeap.Count) switch
        {
            (0, 0) => 0,
            (0, _) => _maxHeap.Peek(),
            (_, 0) => _minHeap.Peek(),
            _ when _minHeap.Count == _maxHeap.Count => (_maxHeap.Peek() + _minHeap.Peek()) / 2d,
            _ when _minHeap.Count > _maxHeap.Count => _minHeap.Peek(),
            _ => _maxHeap.Peek()
        };
    }
}
