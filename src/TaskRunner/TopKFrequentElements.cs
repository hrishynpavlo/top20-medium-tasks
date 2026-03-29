namespace TaskRunner;

public class TopKFrequentElements
{
    public int[] TopKFrequent(int[] nums, int k)
    {
        var map = new Dictionary<int, int>();
        var heap = new PriorityQueue<int, int>();
        
        var result = new int[k];

        foreach (var element in nums)
        {
            var frequency = map.GetValueOrDefault(element, 0) + 1;
            map[element] = frequency;
        }

        foreach (var (element, frequency) in map)
        {
            if (heap.Count < k)
            {
                heap.Enqueue(element, frequency);
            }
            else if(heap.TryPeek(out _, out var minFrequency) && minFrequency < frequency)
            {
                heap.EnqueueDequeue(element, frequency);
            }
        }

        for (int i = 0; i < result.Length; i++)
        {
            result[i] = heap.Dequeue();
        }

        return result;
    }
}