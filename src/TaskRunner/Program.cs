namespace TaskRunner;

static class Program
{
    static void Main(string[] args)
    {
        var cache = new TimeMap<string, string>();
        
        cache.Set("foo", "bar", 1);
        cache.Set("foo", "bar", 2);
        cache.Set("foo", "bar", 3);
        cache.Set("foo", "bar", 4);
        cache.Set("foo", "bar", 5);
        cache.Get("foo", 1);
        Console.ReadLine();
    }
}