using TaskRunner;

namespace Tester;

public class TimeMapTests
{
    [Fact]
    public void MultipleValuesForSameKey()
    {
        var timeMap = new TimeMap<string, string>();

        timeMap.Set("foo", "bar", 1);
        timeMap.Set("foo", "bar2", 4);

        Assert.Equal("bar2", timeMap.Get("foo", 4));
        Assert.Equal("bar2", timeMap.Get("foo", 5));
    }

    [Fact]
    public void TimestampBetweenValues()
    {
        var timeMap = new TimeMap<string, string>();

        timeMap.Set("foo", "bar", 1);
        timeMap.Set("foo", "bar2", 4);

        Assert.Equal("bar", timeMap.Get("foo", 2));
    }

    [Fact]
    public void NoValidTimestamp()
    {
        var timeMap = new TimeMap<string, string>();

        timeMap.Set("foo", "bar", 5);

        Assert.Equal(null!, timeMap.Get("foo", 1));
    }

    [Fact]
    public void MultipleKeys()
    {
        var timeMap = new TimeMap<string, string>();

        timeMap.Set("foo", "bar", 1);
        timeMap.Set("baz", "qux", 2);

        Assert.Equal("bar", timeMap.Get("foo", 1));
        Assert.Equal("qux", timeMap.Get("baz", 2));
        Assert.Equal("qux", timeMap.Get("baz", 3));
    }

    [Fact]
    public void ManyUpdatesSameKey()
    {
        var timeMap = new TimeMap<string, string>();

        timeMap.Set("a", "x1", 1);
        timeMap.Set("a", "x2", 2);
        timeMap.Set("a", "x3", 3);
        timeMap.Set("a", "x4", 4);

        Assert.Equal("x3", timeMap.Get("a", 3));
        Assert.Equal("x4", timeMap.Get("a", 4));
        Assert.Equal("x4", timeMap.Get("a", 5));
    }

    [Fact]
    public void KeyDoesNotExist()
    {
        var timeMap = new TimeMap<string, string>();

        Assert.Equal(null!, timeMap.Get("unknown", 10));
    }

    [Fact]
    public void EdgeTimestampCases()
    {
        var timeMap = new TimeMap<string, string>();

        timeMap.Set("k", "v1", 10);

        Assert.Equal(null!, timeMap.Get("k", 9));
        Assert.Equal("v1", timeMap.Get("k", 10));
        Assert.Equal("v1", timeMap.Get("k", 11));
    }
}