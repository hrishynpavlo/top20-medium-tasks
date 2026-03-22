using TaskRunner;

namespace Tester;

public class AllOneTests
{
    [Fact]
    public void GetMaxKey_Empty_ReturnsEmptyString()
    {
        var allOne = new AllOne();

        Assert.Equal("", allOne.GetMaxKey());
    }

    [Fact]
    public void GetMinKey_Empty_ReturnsEmptyString()
    {
        var allOne = new AllOne();

        Assert.Equal("", allOne.GetMinKey());
    }

    [Fact]
    public void Inc_SingleKey_GetMaxAndMinReturnSameKey()
    {
        var allOne = new AllOne();

        allOne.Inc("a");

        Assert.Equal("a", allOne.GetMaxKey());
        Assert.Equal("a", allOne.GetMinKey());
    }

    [Fact]
    public void Inc_TwoKeys_GetMaxReturnsMoreFrequent()
    {
        var allOne = new AllOne();

        allOne.Inc("a");
        allOne.Inc("a");
        allOne.Inc("b");  // count: a=2, b=1

        Assert.Equal("a", allOne.GetMaxKey());
        Assert.Equal("b", allOne.GetMinKey());
    }

    [Fact]
    public void Inc_ThreeKeys_CorrectMaxAndMin()
    {
        var allOne = new AllOne();

        allOne.Inc("a");
        allOne.Inc("a");
        allOne.Inc("a");  // a=3
        allOne.Inc("b");
        allOne.Inc("b");  // b=2
        allOne.Inc("c");  // c=1

        Assert.Equal("a", allOne.GetMaxKey());
        Assert.Equal("c", allOne.GetMinKey());
    }

    [Fact]
    public void Dec_KeyToZero_KeyIsRemoved()
    {
        var allOne = new AllOne();

        allOne.Inc("a");
        allOne.Inc("b");
        allOne.Dec("a");  // a removed, only b remains

        Assert.Equal("b", allOne.GetMaxKey());
        Assert.Equal("b", allOne.GetMinKey());
    }

    [Fact]
    public void Dec_UpdatesMinKey()
    {
        var allOne = new AllOne();

        allOne.Inc("a");
        allOne.Inc("a");
        allOne.Inc("b");
        allOne.Inc("b");  // a=2, b=2
        allOne.Dec("b");  // a=2, b=1

        Assert.Equal("a", allOne.GetMaxKey());
        Assert.Equal("b", allOne.GetMinKey());
    }

    [Fact]
    public void Dec_UpdatesMaxKey()
    {
        var allOne = new AllOne();

        allOne.Inc("a");
        allOne.Inc("a");
        allOne.Inc("b");  // a=2, b=1
        allOne.Dec("a");  // a=1, b=1 — both equal

        // both have count=1, either is valid for max/min
        var max = allOne.GetMaxKey();
        var min = allOne.GetMinKey();
        Assert.True(max == "a" || max == "b");
        Assert.True(min == "a" || min == "b");
    }

    [Fact]
    public void Dec_LastKeyToZero_GetMaxAndMinReturnEmpty()
    {
        var allOne = new AllOne();

        allOne.Inc("a");
        allOne.Dec("a");  // removed — structure is empty again

        Assert.Equal("", allOne.GetMaxKey());
        Assert.Equal("", allOne.GetMinKey());
    }

    [Fact]
    public void LeetCode_Example1()
    {
        var allOne = new AllOne();

        allOne.Inc("hello");
        allOne.Inc("hello");
        Assert.Equal("hello", allOne.GetMaxKey());
        Assert.Equal("hello", allOne.GetMinKey());

        allOne.Inc("leet");
        Assert.Equal("hello", allOne.GetMaxKey());  // hello=2, leet=1
        Assert.Equal("leet",  allOne.GetMinKey());
    }

    [Fact]
    public void GetMaxKey_TieCount_ReturnsAnyValidKey()
    {
        var allOne = new AllOne();

        allOne.Inc("a");
        allOne.Inc("b");
        allOne.Inc("c");  // a=b=c=1

        var max = allOne.GetMaxKey();
        Assert.True(max == "a" || max == "b" || max == "c");
    }

    [Fact]
    public void GetMinKey_TieCount_ReturnsAnyValidKey()
    {
        var allOne = new AllOne();

        allOne.Inc("a");
        allOne.Inc("b");
        allOne.Inc("a");
        allOne.Inc("b");  // a=b=2

        var min = allOne.GetMinKey();
        Assert.True(min == "a" || min == "b");
    }

    [Fact]
    public void LeetCode_LargeSequence_IncDecMix()
    {
        var allOne = new AllOne();

        // inc hello, world, leet, code, ds, leet  →  leet:2, rest:1
        allOne.Inc("hello");
        allOne.Inc("world");
        allOne.Inc("leet");
        allOne.Inc("code");
        allOne.Inc("ds");
        allOne.Inc("leet");
        Assert.Equal("leet", allOne.GetMaxKey());   // leet:2

        // inc ds → ds:2, dec leet → leet:1
        allOne.Inc("ds");
        allOne.Dec("leet");
        Assert.Equal("ds", allOne.GetMaxKey());     // ds:2

        // dec ds → ds:1, inc hello → hello:2
        allOne.Dec("ds");
        allOne.Inc("hello");
        Assert.Equal("hello", allOne.GetMaxKey());  // hello:2

        // inc hello × 2 → hello:4
        allOne.Inc("hello");
        allOne.Inc("hello");

        // dec world, leet, code, ds → all removed (were at count 1)
        allOne.Dec("world");
        allOne.Dec("leet");
        allOne.Dec("code");
        allOne.Dec("ds");
        Assert.Equal("hello", allOne.GetMaxKey());  // only hello:4

        // inc new × 6 → new:6, hello:4 remains
        allOne.Inc("new");
        allOne.Inc("new");
        allOne.Inc("new");
        allOne.Inc("new");
        allOne.Inc("new");
        allOne.Inc("new");
        Assert.Equal("new",   allOne.GetMaxKey());  // new:6
        Assert.Equal("hello", allOne.GetMinKey());  // hello:4
    }
}

