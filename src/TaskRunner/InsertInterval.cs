namespace TaskRunner;

public class InsertInterval
{
    public int[][] Insert(int[][] intervals, int[] newInterval)
    {
        var inserted = false;

        var start = newInterval[0];
        var end = newInterval[1];

        var result = new List<int[]>();
        
        for (var i = 0; i < intervals.Length; i++)
        { 
            var interval = intervals[i];
            int intervalStart = interval[0];
            int intervalEnd = interval[1];

            if (intervalEnd < start || intervalStart > end)
            {
                if (!inserted && intervalStart > end)
                {
                    result.Add(newInterval);
                    inserted = true;
                }
                
                result.Add(interval);
                continue;
            }
            
            intervalStart = Math.Min(intervalStart, start);

            while (i < intervals.Length && intervals[i][0] <= end)
            {
                intervalEnd = Math.Max(intervals[i][1], end);
                i++;
            }

            i--;

            result.Add([intervalStart, intervalEnd]);
            inserted = true;
        }

        if(!inserted) result.Add(newInterval);
        
        return result.ToArray();
    }
}