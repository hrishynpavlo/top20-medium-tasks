using TaskRunner;

namespace Tester;

public class LongestSubstringKDistinctTests
{
    private readonly LongestSubstringKDistinct _sut = new();

    [Fact]
    public void LengthOfLongestSubstringKDistinct_Example1_Returns3()
    {
        var result = _sut.LengthOfLongestSubstringKDistinct("eceba", 2);

        Assert.Equal(3, result);
    }

    [Fact]
    public void LengthOfLongestSubstringKDistinct_Example2_Returns2()
    {
        var result = _sut.LengthOfLongestSubstringKDistinct("aa", 1);

        Assert.Equal(2, result);
    }

    [Fact]
    public void LengthOfLongestSubstringKDistinct_KEqualsZero_ReturnsZero()
    {
        var result = _sut.LengthOfLongestSubstringKDistinct("abc", 0);

        Assert.Equal(0, result);
    }

    [Fact]
    public void LengthOfLongestSubstringKDistinct_KGreaterThanDistinct_ReturnsWholeString()
    {
        var result = _sut.LengthOfLongestSubstringKDistinct("abc", 10);

        Assert.Equal(3, result);
    }

    [Fact]
    public void LengthOfLongestSubstringKDistinct_AllSameChars_ReturnsFullLength()
    {
        var result = _sut.LengthOfLongestSubstringKDistinct("aaaa", 1);

        Assert.Equal(4, result);
    }

    [Fact]
    public void LengthOfLongestSubstringKDistinct_WindowInMiddle_ReturnsCorrectLength()
    {
        // "aabbcc", k=2 → "aabb" or "bbcc" → 4
        var result = _sut.LengthOfLongestSubstringKDistinct("aabbcc", 2);

        Assert.Equal(4, result);
    }

    [Fact]
    public void LengthOfLongestSubstringKDistinct_SingleChar_Returns1()
    {
        var result = _sut.LengthOfLongestSubstringKDistinct("z", 1);

        Assert.Equal(1, result);
    }

    [Fact]
    public void LengthOfLongestSubstringKDistinct_KEqualsDistinctCount_ReturnsWholeString()
    {
        var result = _sut.LengthOfLongestSubstringKDistinct("abaccc", 3);

        Assert.Equal(6, result);
    }

    [Fact]
    public void LengthOfLongestSubstringKDistinct_GhostKeyBug_ReturnsCorrectLength()
    {
        // "aabbcdddd", k=2
        // После того как окно "aabb" (a,b) выдвигается вправо и встречает 'c',
        // shrink должен уменьшить счётчики 'a' и 'b' до 0 и удалить их.
        // Без декремента они остаются ghost-ключами в словаре →
        // все последующие 'd' видят 3 distinct и тут же выбрасываются,
        // окно "cdddd" (c,d = 2 distinct, length=5) никогда не собирается.
        var result = _sut.LengthOfLongestSubstringKDistinct("aabbcdddd", 2);

        Assert.Equal(5, result); // "cdddd"
    }
}

