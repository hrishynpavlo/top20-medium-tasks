using TaskRunner;

namespace Tester;

public class TopKFrequentElementsTests
{
    private readonly TopKFrequentElements _sut = new();

    private static int[] Sorted(int[] arr) => arr.OrderBy(x => x).ToArray();

    [Fact]
    public void TopKFrequent_BasicCase_ReturnsTwoMostFrequent()
    {
        var result = _sut.TopKFrequent([1, 1, 1, 2, 2, 3], 2);

        Assert.Equal([1, 2], Sorted(result));
    }

    [Fact]
    public void TopKFrequent_KEquals1_ReturnsMostFrequent()
    {
        var result = _sut.TopKFrequent([3, 0, 1, 0], 1);

        Assert.Equal([0], Sorted(result));
    }

    [Fact]
    public void TopKFrequent_SingleElement_ReturnsThatElement()
    {
        var result = _sut.TopKFrequent([42], 1);

        Assert.Equal([42], Sorted(result));
    }

    [Fact]
    public void TopKFrequent_KEqualsArrayLength_ReturnsAllElements()
    {
        var result = _sut.TopKFrequent([1, 2, 3], 3);

        Assert.Equal([1, 2, 3], Sorted(result));
    }

    [Fact]
    public void TopKFrequent_NegativeNumbers_ReturnsCorrectElements()
    {
        var result = _sut.TopKFrequent([-1, -1, 2, 2, 2, 3], 2);

        Assert.Equal([-1, 2], Sorted(result));
    }

    [Fact]
    public void TopKFrequent_ClearWinner_ReturnsMostFrequent()
    {
        var result = _sut.TopKFrequent([4, 4, 4, 4, 1, 2, 3], 1);

        Assert.Equal([4], Sorted(result));
    }

    [Fact]
    public void TopKFrequent_MultipleFrequencies_ReturnsTopK()
    {
        var result = _sut.TopKFrequent([1, 1, 1, 2, 2, 3, 3, 3, 3], 2);

        Assert.Equal([1, 3], Sorted(result));
    }

    [Fact]
    public void TopKFrequent_AllSameFrequency_ReturnsKElements()
    {
        var result = _sut.TopKFrequent([1, 2, 3, 4, 5], 3);

        Assert.Equal(3, result.Length);
    }
}

