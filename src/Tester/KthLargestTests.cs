using TaskRunner;

namespace Tester;

public class KthLargestTests
{
    [Fact]
    public void Example1_ReturnsCorrectKthLargest()
    {
        // k=3, nums=[4,5,8,2]
        // sorted descending: [8,5,4,2] → 3rd largest = 4
        var kth = new KthLargest(3, [4, 5, 8, 2]);

        Assert.Equal(4, kth.Add(3));   // pool: [2,3,4,5,8] → 3rd = 4
        Assert.Equal(5, kth.Add(5));   // pool: [2,3,4,5,5,8] → 3rd = 5
        Assert.Equal(5, kth.Add(10));  // pool: [2,3,4,5,5,8,10] → 3rd = 5
        Assert.Equal(8, kth.Add(9));   // pool: [2,3,4,5,5,8,9,10] → 3rd = 8
        Assert.Equal(8, kth.Add(4));   // pool: [2,3,4,4,5,5,8,9,10] → 3rd = 8
    }

    [Fact]
    public void Example2_ReturnsCorrectKthLargest()
    {
        // k=4, nums=[7,7,7,7,8,3]
        // sorted descending: [8,7,7,7,7,3] → 4th = 7
        var kth = new KthLargest(4, [7, 7, 7, 7, 8, 3]);

        Assert.Equal(7, kth.Add(2));   // 4th = 7
        Assert.Equal(7, kth.Add(10));  // 4th = 7
        Assert.Equal(7, kth.Add(9));   // 4th = 7
        Assert.Equal(8, kth.Add(9));   // 4th = 8
    }

    [Fact]
    public void EmptyInitialNums_AddsElementsCorrectly()
    {
        // k=1, stream starts empty — kth largest = max
        var kth = new KthLargest(1, []);

        Assert.Equal(5, kth.Add(5));
        Assert.Equal(7, kth.Add(7));
        Assert.Equal(7, kth.Add(3));
    }

    [Fact]
    public void K1_AlwaysReturnsCurrentMax()
    {
        var kth = new KthLargest(1, [2, 4]);

        Assert.Equal(6, kth.Add(6));
        Assert.Equal(6, kth.Add(1));
        Assert.Equal(9, kth.Add(9));
    }

    [Fact]
    public void NegativeNumbers_HandledCorrectly()
    {
        // k=2, nums=[-5,-3,-1]
        // sorted descending: [-1,-3,-5] → 2nd = -3
        var kth = new KthLargest(2, [-5, -3, -1]);

        Assert.Equal(-3, kth.Add(-10)); // pool sorted desc: [-1,-3,-5,-10] → 2nd = -3
        Assert.Equal(-1, kth.Add(0));   // pool: [0,-1,-3,-5,-10] → 2nd = -1
    }

    [Fact]
    public void DuplicateValues_HandledCorrectly()
    {
        // k=3, nums=[5,5,5,5]
        // sorted descending: [5,5,5,5] → 3rd = 5
        var kth = new KthLargest(3, [5, 5, 5, 5]);

        Assert.Equal(5, kth.Add(5));
        Assert.Equal(5, kth.Add(1));
    }

    [Fact]
    public void InitialNumsLargerThanK_CorrectlyInitialized()
    {
        // k=2, nums=[10,20,30,40,50]
        // 2nd largest from initial = 40
        var kth = new KthLargest(2, [10, 20, 30, 40, 50]);

        Assert.Equal(40, kth.Add(1));  // no change in top-2
        Assert.Equal(45, kth.Add(45)); // new 2nd largest = 45
        Assert.Equal(50, kth.Add(55)); // new 2nd largest = 50
    }

    [Fact]
    public void InitialNumsSmallerThanK_AddsUntilKReached()
    {
        // k=3, nums=[1] — only 1 element, need 2 more before kth is valid
        var kth = new KthLargest(3, [1]);

        Assert.Equal(1, kth.Add(2));  // pool: [1,2] — still only 2 els, 3rd = 1
        Assert.Equal(1, kth.Add(3));  // pool: [1,2,3] — 3rd = 1
        Assert.Equal(2, kth.Add(4));  // pool: [1,2,3,4] — 3rd = 2
    }
}

