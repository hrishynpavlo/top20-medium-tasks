using TaskRunner;

namespace Tester;

public class RateLimiterTests
{
    private static RateLimiter Create(int maxRequests = 3, long windowMs = 1000)
        => new(maxRequests, windowMs);

    [Fact]
    public void Allow_FirstRequest_ReturnsTrue()
    {
        var sut = Create();

        Assert.True(sut.Allow("user1", 0));
    }

    [Fact]
    public void Allow_WithinLimit_AllAllowed()
    {
        var sut = Create(maxRequests: 3);

        Assert.True(sut.Allow("user1", 0));
        Assert.True(sut.Allow("user1", 100));
        Assert.True(sut.Allow("user1", 200));
    }

    [Fact]
    public void Allow_ExactlyAtLimit_ReturnsTrue()
    {
        var sut = Create(maxRequests: 3);

        sut.Allow("user1", 0);
        sut.Allow("user1", 100);

        Assert.True(sut.Allow("user1", 200)); // 3rd = exactly at limit
    }

    [Fact]
    public void Allow_ExceedingLimit_ReturnsFalse()
    {
        var sut = Create(maxRequests: 3, windowMs: 1000);

        sut.Allow("user1", 0);
        sut.Allow("user1", 100);
        sut.Allow("user1", 200);

        Assert.False(sut.Allow("user1", 300)); // 4th inside same window
    }

    [Fact]
    public void Allow_AfterWindowFullyExpires_ReturnsTrue()
    {
        var sut = Create(maxRequests: 3, windowMs: 1000);

        sut.Allow("user1", 0);
        sut.Allow("user1", 100);
        sut.Allow("user1", 200);

        Assert.True(sut.Allow("user1", 1200)); // window [200..1200] — старые выпали
    }

    [Fact]
    public void Allow_SlidingWindow_OldestRequestLeavesWindow_Allowed()
    {
        var sut = Create(maxRequests: 3, windowMs: 1000);

        sut.Allow("user1", 0);   // выпадет при t=1001 (window = [1..1001])
        sut.Allow("user1", 500);
        sut.Allow("user1", 600);

        // window [1..1001]: t=0 выпал → в окне только 500,600 → 2 < 3 → разрешено
        Assert.True(sut.Allow("user1", 1001));
    }

    [Fact]
    public void Allow_SlidingWindow_OldestRequestStillInWindow_Blocked()
    {
        var sut = Create(maxRequests: 3, windowMs: 1000);

        sut.Allow("user1", 0);
        sut.Allow("user1", 500);
        sut.Allow("user1", 600);

        // window [0..999]: все три ещё в окне → заблокировано
        Assert.False(sut.Allow("user1", 999));
    }

    [Fact]
    public void Allow_DifferentUsers_AreIndependent()
    {
        var sut = Create(maxRequests: 2);

        sut.Allow("user1", 0);
        sut.Allow("user1", 100);
        Assert.False(sut.Allow("user1", 200)); // user1 исчерпан

        Assert.True(sut.Allow("user2", 200)); // user2 не затронут
    }

    [Fact]
    public void Allow_MaxRequestsOne_SecondRequestBlocked_ThenAllowedAfterWindow()
    {
        var sut = Create(maxRequests: 1, windowMs: 1000);

        Assert.True(sut.Allow("user1", 0));
        Assert.False(sut.Allow("user1", 500));
        Assert.True(sut.Allow("user1", 1001)); // t=0 выпал из окна
    }
}

