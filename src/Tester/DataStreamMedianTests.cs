using TaskRunner;

namespace Tester;

public class DataStreamMedianTests
{
    [Fact]
    public void Median_WithTwoNumbers()
    {
        var mf = new DataStreamMedian();

        mf.AddNum(1);
        mf.AddNum(2);

        Assert.Equal(1.5, mf.FindMedian());
    }

    [Fact]
    public void Median_WithOddCount()
    {
        var mf = new DataStreamMedian();

        mf.AddNum(1);
        mf.AddNum(2);
        mf.AddNum(3);

        Assert.Equal(2, mf.FindMedian());
    }

    [Fact]
    public void Median_WithEvenCount()
    {
        var mf = new DataStreamMedian();

        mf.AddNum(1);
        mf.AddNum(2);
        mf.AddNum(3);
        mf.AddNum(4);

        Assert.Equal(2.5, mf.FindMedian());
    }

    [Fact]
    public void Median_WithNegativeNumbers()
    {
        var mf = new DataStreamMedian();

        mf.AddNum(-5);
        mf.AddNum(-10);
        mf.AddNum(-3);

        Assert.Equal(-5, mf.FindMedian());
    }

    [Fact]
    public void Median_WithMixedNumbers()
    {
        var mf = new DataStreamMedian();

        mf.AddNum(-1);
        mf.AddNum(0);
        mf.AddNum(1);

        Assert.Equal(0, mf.FindMedian());
    }

    [Fact]
    public void Median_StreamExample()
    {
        var mf = new DataStreamMedian();

        mf.AddNum(1);
        Assert.Equal(1, mf.FindMedian());

        mf.AddNum(2);
        Assert.Equal(1.5, mf.FindMedian());

        mf.AddNum(3);
        Assert.Equal(2, mf.FindMedian());
    }

    [Fact]
    public void Median_WithDuplicateValues()
    {
        var mf = new DataStreamMedian();

        mf.AddNum(5);
        mf.AddNum(5);
        mf.AddNum(5);
        mf.AddNum(5);

        Assert.Equal(5, mf.FindMedian());
    }

    [Fact]
    public void Median_WithUnsortedInput()
    {
        var mf = new DataStreamMedian();

        mf.AddNum(10);
        mf.AddNum(1);
        mf.AddNum(5);
        mf.AddNum(2);
        mf.AddNum(8);

        Assert.Equal(5, mf.FindMedian());
    }
}