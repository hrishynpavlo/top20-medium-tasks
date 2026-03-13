namespace TaskRunner;

public class TimeMap<TKey, TValue> where TKey : notnull
{
    public void Set(TKey key, TValue value, int timestamp)
    {
        
    }

    public TValue? Get(TKey key, int timestamp)
    {
        return default;
    }
}