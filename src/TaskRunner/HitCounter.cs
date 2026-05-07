namespace TaskRunner;

public class HitCounter
{
    private readonly int[] _hits = new int[300];
    private readonly int[] _timestamps = new int[300];

    public void Hit(int timestamp)
    {
        var index = timestamp % 300;

        if (_timestamps[index] != timestamp)
        {
            _hits[index] = 1;
        }
        else
        {
            _hits[index]++;
        }
        
        _timestamps[index] = timestamp;
    }

    public int GetHits(int timestamp)
    {
        var result = 0;
        for (int i = 0; i < 300; i++)
        {
            if (_timestamps[i] > timestamp - 300)
            {
                result += _hits[i];
            }
        }

        return result;
    }
}

