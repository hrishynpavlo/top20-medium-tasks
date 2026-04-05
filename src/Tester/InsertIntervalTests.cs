using TaskRunner;

namespace Tester;

public class InsertIntervalTests
{
    private readonly InsertInterval _sut = new();

    [Fact]
    public void Insert_LeetcodeExample1_MergesOverlapping()
    {
        // [[1,3],[6,9]] + [2,5] => [[1,5],[6,9]]
        var result = _sut.Insert([[1, 3], [6, 9]], [2, 5]);

        Assert.Equal([[1, 5], [6, 9]], result);
    }

    [Fact]
    public void Insert_LeetcodeExample2_MergesMultiple()
    {
        // [[1,2],[3,5],[6,7],[8,10],[12,16]] + [4,8] => [[1,2],[3,10],[12,16]]
        var result = _sut.Insert([[1, 2], [3, 5], [6, 7], [8, 10], [12, 16]], [4, 8]);

        Assert.Equal([[1, 2], [3, 10], [12, 16]], result);
    }

    [Fact]
    public void Insert_EmptyIntervals_ReturnsSingleInterval()
    {
        // [] + [5,7] => [[5,7]]
        var result = _sut.Insert([], [5, 7]);

        Assert.Equal([[5, 7]], result);
    }

    [Fact]
    public void Insert_BeforeAll_PrependInterval()
    {
        // [[3,5],[6,9]] + [1,2] => [[1,2],[3,5],[6,9]]
        var result = _sut.Insert([[3, 5], [6, 9]], [1, 2]);

        Assert.Equal([[1, 2], [3, 5], [6, 9]], result);
    }

    [Fact]
    public void Insert_AfterAll_AppendInterval()
    {
        // [[1,3],[6,9]] + [10,15] => [[1,3],[6,9],[10,15]]
        var result = _sut.Insert([[1, 3], [6, 9]], [10, 15]);

        Assert.Equal([[1, 3], [6, 9], [10, 15]], result);
    }

    [Fact]
    public void Insert_OverlapsAll_ReturnsSingleInterval()
    {
        // [[1,3],[4,6],[7,9]] + [0,10] => [[0,10]]
        var result = _sut.Insert([[1, 3], [4, 6], [7, 9]], [0, 10]);

        Assert.Equal([[0, 10]], result);
    }

    [Fact]
    public void Insert_ContainedWithin_NoChange()
    {
        // [[1,5]] + [2,3] => [[1,5]]
        var result = _sut.Insert([[1, 5]], [2, 3]);

        Assert.Equal([[1, 5]], result);
    }

    [Fact]
    public void Insert_TouchingEdges_MergesIntoOne()
    {
        // [[1,5],[6,9]] + [5,6] => [[1,9]]
        var result = _sut.Insert([[1, 5], [6, 9]], [5, 6]);

        Assert.Equal([[1, 9]], result);
    }

    [Fact]
    public void Insert_SingleInterval_OverlapsMerges()
    {
        // [[1,5]] + [2,7] => [[1,7]]
        var result = _sut.Insert([[1, 5]], [2, 7]);

        Assert.Equal([[1, 7]], result);
    }

    [Fact]
    public void Insert_NoOverlap_InsertsInMiddle()
    {
        // [[1,2],[8,10]] + [4,6] => [[1,2],[4,6],[8,10]]
        var result = _sut.Insert([[1, 2], [8, 10]], [4, 6]);

        Assert.Equal([[1, 2], [4, 6], [8, 10]], result);
    }
}

