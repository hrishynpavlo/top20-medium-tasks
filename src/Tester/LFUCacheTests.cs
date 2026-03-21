using TaskRunner;

namespace Tester;

public class LFUCacheTests
{
    [Fact]
    public void Get_ExistingKey_ReturnsValue()
    {
        var cache = new LFUCache(2);

        cache.Put(1, 10);

        Assert.Equal(10, cache.Get(1));
    }

    [Fact]
    public void Get_MissingKey_ReturnsMinus1()
    {
        var cache = new LFUCache(2);

        Assert.Equal(-1, cache.Get(42));
    }

    [Fact]
    public void Put_OverCapacity_EvictsLeastFrequentlyUsed()
    {
        var cache = new LFUCache(2);

        cache.Put(1, 1);
        cache.Put(2, 2);
        cache.Get(1);       // freq(1)=2, freq(2)=1
        cache.Put(3, 3);    // key 2 is LFU → evicted

        Assert.Equal(-1, cache.Get(2));  // evicted
        Assert.Equal(1,  cache.Get(1));
        Assert.Equal(3,  cache.Get(3));
    }

    [Fact]
    public void Put_OverCapacity_TieBreaksByLeastRecentlyUsed()
    {
        var cache = new LFUCache(2);

        cache.Put(1, 1);  // freq 1
        cache.Put(2, 2);  // freq 1  — key 1 is LRU among freq-1 keys
        cache.Put(3, 3);  // key 1 evicted (same freq, inserted earlier)

        Assert.Equal(-1, cache.Get(1));  // evicted
        Assert.Equal(2,  cache.Get(2));
        Assert.Equal(3,  cache.Get(3));
    }

    [Fact]
    public void Put_CapacityOne_AlwaysEvictsPrevious()
    {
        var cache = new LFUCache(1);

        cache.Put(1, 1);
        cache.Put(2, 2);

        Assert.Equal(-1, cache.Get(1));  // evicted
        Assert.Equal(2,  cache.Get(2));
    }

    [Fact]
    public void Put_UpdateExistingKey_UpdatesValueAndFrequency()
    {
        var cache = new LFUCache(2);

        cache.Put(1, 1);
        cache.Put(2, 2);
        cache.Put(1, 10);   // update key 1 → freq(1)=2, freq(2)=1
        cache.Put(3, 3);    // key 2 is LFU → evicted

        Assert.Equal(10, cache.Get(1));  // updated value
        Assert.Equal(-1, cache.Get(2));  // evicted
        Assert.Equal(3,  cache.Get(3));
    }

    [Fact]
    public void Get_IncreasesFrequency_PreventsEviction()
    {
        var cache = new LFUCache(2);

        cache.Put(1, 1);
        cache.Put(2, 2);
        cache.Get(2);       // freq(2)=2, freq(1)=1
        cache.Put(3, 3);    // key 1 is LFU → evicted

        Assert.Equal(-1, cache.Get(1));  // evicted
        Assert.Equal(2,  cache.Get(2));
        Assert.Equal(3,  cache.Get(3));
    }

    [Fact]
    public void LeetCode_Example1()
    {
        var cache = new LFUCache(2);

        cache.Put(1, 1);   // cache: {1=1}
        cache.Put(2, 2);   // cache: {1=1, 2=2}
        Assert.Equal(1, cache.Get(1));   // freq(1)=2
        cache.Put(3, 3);   // evicts key 2 (freq=1, LRU)
        Assert.Equal(-1, cache.Get(2));  // evicted
        Assert.Equal(3,  cache.Get(3));  // freq(3)=2
        cache.Put(4, 4);   // evicts key 1 (freq=2, LRU vs 3 which was just used)
        Assert.Equal(-1, cache.Get(1));  // evicted
        Assert.Equal(3,  cache.Get(3));
        Assert.Equal(4,  cache.Get(4));
    }

    [Fact]
    public void MultipleUpdates_FrequencyAccumulatesCorrectly()
    {
        var cache = new LFUCache(2);

        cache.Put(1, 1);
        cache.Put(2, 2);

        // Make key 1 very frequent
        cache.Get(1);
        cache.Get(1);
        cache.Get(1);   // freq(1)=4, freq(2)=1

        cache.Put(3, 3);    // key 2 evicted
        Assert.Equal(1,  cache.Get(1));
        Assert.Equal(-1, cache.Get(2));
        Assert.Equal(3,  cache.Get(3));
    }
}

