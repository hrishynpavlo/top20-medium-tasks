using TaskRunner;

namespace Tester;

public class MinimumWindowSubstringTests
{
    private readonly MinimumWindowSubstring _sut = new();

    [Fact]
    public void MinWindow_Example1_ReturnsBANC()
    { 
        var result = _sut.MinWindow("ADOBECODEBANC", "ABC");

        Assert.Equal("BANC", result);
    }

    [Fact]
    public void MinWindow_SingleCharMatch_ReturnsSingleChar()
    {
        var result = _sut.MinWindow("a", "a");

        Assert.Equal("a", result);
    }

    [Fact]
    public void MinWindow_NotEnoughChars_ReturnsEmpty()
    {
        var result = _sut.MinWindow("a", "aa");

        Assert.Equal(string.Empty, result);
    }

    [Fact]
    public void MinWindow_NoMatch_ReturnsEmpty()
    {
        var result = _sut.MinWindow("ADOBECODEBANC", "XYZ");

        Assert.Equal(string.Empty, result);
    }

    [Fact]
    public void MinWindow_SEqualsT_ReturnsWholeString()
    {
        var result = _sut.MinWindow("ABC", "ABC");

        Assert.Equal("ABC", result);
    }

    [Fact]
    public void MinWindow_WindowAtStart_ReturnsCorrectSubstring()
    {
        var result = _sut.MinWindow("ABCDE", "AB");

        Assert.Equal("AB", result);
    }

    [Fact]
    public void MinWindow_WindowAtEnd_ReturnsCorrectSubstring()
    {
        var result = _sut.MinWindow("CDEAB", "AB");

        Assert.Equal("AB", result);
    }

    [Fact]
    public void MinWindow_DuplicateCharsInT_ReturnsCorrectWindow()
    {
        var result = _sut.MinWindow("XAAYZ", "AA");

        Assert.Equal("AA", result);
    }

    [Fact]
    public void MinWindow_MultipleCandidates_ReturnsSmallest()
    {
        var result = _sut.MinWindow("ADOBECODEBANC", "ABC");

        Assert.Equal("BANC", result);
    }

    [Fact]
    public void MinWindow_SingleCharS_MultiCharT_ReturnsEmpty()
    {
        var result = _sut.MinWindow("A", "AB");

        Assert.Equal(string.Empty, result);
    }
}
