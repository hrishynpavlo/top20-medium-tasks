namespace TaskRunner;

public class MeetingRooms
{
    public int MinMeetingRooms(int[][] intervals)
    {
        // sort before putting into min heap
        var sortedIntervals = intervals.OrderBy(x => x[0]).ToArray();
        
        var heap = new PriorityQueue<int, int>();
        
        foreach (var interval in sortedIntervals)
        {
            var start = interval[0];
            var end = interval[1];
            
            if(heap.Count > 0 && heap.Peek() <= start)
            {
                heap.DequeueEnqueue(end, end);
            }
            else
            {
                heap.Enqueue(end, end);
            }
        }

        return heap.Count;
    }
}