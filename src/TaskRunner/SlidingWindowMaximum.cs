namespace TaskRunner;

public class SlidingWindowMaximum
{
    private readonly LinkedList<int> _queue = new LinkedList<int>();
    
    public int[] MaxSlidingWindow(int[] nums, int k)
    {
        if(k <= 0) 
            throw new ArgumentOutOfRangeException(nameof(k), "k must be greater than 0");
        
        if (k > nums.Length) 
            throw new ArgumentException("Length of given array must be greater than k", nameof(k));

        if (k == 1) return nums;
        
        var result = new int[nums.Length - k + 1];

        for (int i = 0; i < nums.Length; i++)
        {
            // drop old elements
            if(_queue.Count > 0 && _queue.First!.Value < i - k + 1)
                _queue.RemoveFirst();

            // drop smaller elements before putting new one
            while (_queue.Count > 0 && nums[_queue.Last!.Value] < nums[i])
                _queue.RemoveLast();

            _queue.AddLast(i);
            
            if (i >= k - 1)
            {
                result[i - k + 1] = nums[_queue.First!.Value];
            }
        }
        
        return result;
    }
}

