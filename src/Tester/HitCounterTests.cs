using TaskRunner;

namespace Tester;

public class HitCounterTests
{
    [Fact]
    public void GetHits_BasicExample_ReturnsCorrectCount()
    {
        var counter = new HitCounter();
        counter.Hit(1);
        counter.Hit(2);
        counter.Hit(3);

        Assert.Equal(3, counter.GetHits(4));
        Assert.Equal(3, counter.GetHits(300));
        Assert.Equal(0, counter.GetHits(304));
    }

    [Fact]
    public void GetHits_HitsOutsideWindow_NotCounted()
    {
        var counter = new HitCounter();
        counter.Hit(1);
        counter.Hit(100);
        counter.Hit(200);
        counter.Hit(300);

        // At timestamp 301, hit at t=1 is outside 5-minute window (301 - 300 = 1, but 301 - 1 = 300 > 299)
        Assert.Equal(3, counter.GetHits(301));
    }

    [Fact]
    public void GetHits_NoHits_ReturnsZero()
    {
        var counter = new HitCounter();

        Assert.Equal(0, counter.GetHits(1));
        Assert.Equal(0, counter.GetHits(300));
    }

    [Fact]
    public void GetHits_AllHitsExpired_ReturnsZero()
    {
        var counter = new HitCounter();
        counter.Hit(1);
        counter.Hit(2);
        counter.Hit(3);

        Assert.Equal(0, counter.GetHits(304));
    }

    [Fact]
    public void GetHits_SameTimestampMultipleHits_CountsAll()
    {
        var counter = new HitCounter();
        counter.Hit(5);
        counter.Hit(5);
        counter.Hit(5);

        Assert.Equal(3, counter.GetHits(5));
        Assert.Equal(3, counter.GetHits(304));
        Assert.Equal(0, counter.GetHits(305));
    }

    [Fact]
    public void GetHits_SlidingWindowEdge_ExactlyAtBoundary()
    {
        var counter = new HitCounter();
        counter.Hit(1);
        counter.Hit(301);

        // At t=301, hit at t=1 is exactly 300s ago — outside window
        Assert.Equal(1, counter.GetHits(301));
    }

    [Fact]
    public void GetHits_MixedTimestamps_OnlyWindowCounted()
    {
        var counter = new HitCounter();
        counter.Hit(10);
        counter.Hit(50);
        counter.Hit(200);
        counter.Hit(350);
        counter.Hit(500);

        // At t=500: window is [201..500], hits at 200 is out, 350 and 500 are in
        Assert.Equal(2, counter.GetHits(500));
    }
}

