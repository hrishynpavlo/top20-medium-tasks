using TaskRunner;

namespace Tester;

public class SlidingWindowMaximumTests
{
    [Fact]
    public void BasicCase_ReturnsCorrectMaximums()
    {
        var s = new SlidingWindowMaximum();

        var result = s.MaxSlidingWindow([1, 3, -1, -3, 5, 3, 6, 7], 3);

        Assert.Equal([3, 3, 5, 5, 6, 7], result);
    }

    [Fact]
    public void K1_EachElementIsItsOwnMax()
    {
        var s = new SlidingWindowMaximum();

        var result = s.MaxSlidingWindow([4, 2, 7, 1], 1);

        Assert.Equal([4, 2, 7, 1], result);
    }

    [Fact]
    public void KEqualToArrayLength_ReturnsSingleMax()
    {
        var s = new SlidingWindowMaximum();

        var result = s.MaxSlidingWindow([3, 1, 4, 1, 5], 5);

        Assert.Equal([5], result);
    }

    [Fact]
    public void SingleElement_ReturnsThatElement()
    {
        var s = new SlidingWindowMaximum();

        var result = s.MaxSlidingWindow([42], 1);

        Assert.Equal([42], result);
    }

    [Fact]
    public void AllSameElements_ReturnsAllSame()
    {
        var s = new SlidingWindowMaximum();

        var result = s.MaxSlidingWindow([5, 5, 5, 5, 5], 3);

        Assert.Equal([5, 5, 5], result);
    }

    [Fact]
    public void AscendingArray_MaxIsAlwaysRightEdge()
    {
        var s = new SlidingWindowMaximum();

        var result = s.MaxSlidingWindow([1, 2, 3, 4, 5], 3);

        Assert.Equal([3, 4, 5], result);
    }

    [Fact]
    public void DescendingArray_MaxIsAlwaysLeftEdge()
    {
        var s = new SlidingWindowMaximum();

        var result = s.MaxSlidingWindow([5, 4, 3, 2, 1], 3);

        Assert.Equal([5, 4, 3], result);
    }

    [Fact]
    public void AllNegative_ReturnsCorrectMaximums()
    {
        var s = new SlidingWindowMaximum();

        var result = s.MaxSlidingWindow([-5, -3, -1, -4, -2], 2);

        Assert.Equal([-3, -1, -1, -2], result);
    }

    [Fact]
    public void MixedNegativeAndPositive_ReturnsCorrect()
    {
        var s = new SlidingWindowMaximum();

        var result = s.MaxSlidingWindow([-2, 1, -3, 4, -1], 3);

        Assert.Equal([1, 4, 4], result);
    }

    [Fact]
    public void Duplicates_HandledCorrectly()
    {
        var s = new SlidingWindowMaximum();

        var result = s.MaxSlidingWindow([2, 1, 2, 3, 2], 3);

        Assert.Equal([2, 3, 3], result);
    }

    [Fact]
    public void MaxDuplicatedAcrossWindows_ReturnsCorrect()
    {
        var s = new SlidingWindowMaximum();

        var result = s.MaxSlidingWindow([5, 5, 1, 5, 5], 3);

        Assert.Equal([5, 5, 5], result);
    }

    [Fact]
    public void ResultLength_IsNumsLengthMinusKPlusOne()
    {
        var s = new SlidingWindowMaximum();
        int[] nums = [1, 2, 3, 4, 5, 6, 7];
        int k = 3;

        var result = s.MaxSlidingWindow(nums, k);

        Assert.Equal(nums.Length - k + 1, result.Length);
    }
}

