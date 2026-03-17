using TaskRunner;

namespace Tester;

public class LRUCacheTests
{
    [Fact]
    public void Get_ExistingKey_ReturnsValue()
    {
        var cache = new LRUCache<string, int>(2);

        cache.Put("a", 1);

        Assert.Equal(1, cache.Get("a"));
    }

    [Fact]
    public void Get_NonExistingKey_ReturnsDefault()
    {
        var cache = new LRUCache<string, int>(2);

        Assert.Equal(0, cache.Get("missing"));
    }

    [Fact]
    public void Put_OverCapacity_EvictsLeastRecentlyUsed()
    {
        var cache = new LRUCache<string, int>(2);

        cache.Put("a", 1);
        cache.Put("b", 2);
        cache.Put("c", 3); // "a" is LRU — evicted

        Assert.Equal(0, cache.Get("a"));   // evicted
        Assert.Equal(2, cache.Get("b"));
        Assert.Equal(3, cache.Get("c"));
    }

    [Fact]
    public void Get_UpdatesRecency_PreventsEviction()
    {
        var cache = new LRUCache<string, int>(2);

        cache.Put("a", 1);
        cache.Put("b", 2);
        cache.Get("a");     // "a" becomes most recently used
        cache.Put("c", 3);  // "b" is now LRU — evicted

        Assert.Equal(1, cache.Get("a"));   // still alive
        Assert.Equal(0, cache.Get("b"));   // evicted
        Assert.Equal(3, cache.Get("c"));
    }

    [Fact]
    public void Put_UpdatesExistingKey_DoesNotEvict()
    {
        var cache = new LRUCache<string, int>(2);

        cache.Put("a", 1);
        cache.Put("b", 2);
        cache.Put("a", 99); // update — no eviction, "a" becomes MRU
        cache.Put("c", 3);  // "b" is LRU — evicted

        Assert.Equal(99, cache.Get("a"));
        Assert.Equal(0,  cache.Get("b")); // evicted
        Assert.Equal(3,  cache.Get("c"));
    }

    [Fact]
    public void Put_CapacityOne_AlwaysEvictsPrevious()
    {
        var cache = new LRUCache<string, int>(1);

        cache.Put("a", 1);
        cache.Put("b", 2);

        Assert.Equal(0, cache.Get("a")); // evicted
        Assert.Equal(2, cache.Get("b"));
    }

    [Fact]
    public void MultipleEvictions_OrderIsCorrect()
    {
        var cache = new LRUCache<int, int>(3);

        cache.Put(1, 10);
        cache.Put(2, 20);
        cache.Put(3, 30);
        cache.Put(4, 40); // 1 evicted
        cache.Put(5, 50); // 2 evicted

        Assert.Equal(0,  cache.Get(1));
        Assert.Equal(0,  cache.Get(2));
        Assert.Equal(30, cache.Get(3));
        Assert.Equal(40, cache.Get(4));
        Assert.Equal(50, cache.Get(5));
    }

    [Fact]
    public void Put_SameKeyMultipleTimes_UpdatesValue()
    {
        var cache = new LRUCache<string, string>(2);

        cache.Put("x", "v1");
        cache.Put("x", "v2");
        cache.Put("x", "v3");

        Assert.Equal("v3", cache.Get("x"));
    }

    [Fact]
    public void Get_AfterEviction_ReturnsDefault()
    {
        var cache = new LRUCache<int, int>(2);

        cache.Put(1, 100);
        cache.Put(2, 200);
        cache.Put(3, 300); // 1 evicted

        Assert.Equal(0, cache.Get(1));
    }
}

