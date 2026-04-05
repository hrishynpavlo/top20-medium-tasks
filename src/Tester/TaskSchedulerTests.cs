using TaskRunner;
using TaskScheduler = TaskRunner.TaskScheduler;

namespace Tester;

public class TaskSchedulerTests
{
    private readonly TaskScheduler _sut = new();

    [Fact]
    public void LeastInterval_LeetcodeExample1_Returns8()
    {
        // A, A, A, B, B, B with n=2 => A B _ A B _ A B = 8
        var result = _sut.LeastInterval(['A', 'A', 'A', 'B', 'B', 'B'], 2);

        Assert.Equal(8, result);
    }

    [Fact]
    public void LeastInterval_LeetcodeExample2_Returns6()
    {
        // A, A, A, B, B, B with n=0 => no cooldown, just run all tasks
        var result = _sut.LeastInterval(['A', 'A', 'A', 'B', 'B', 'B'], 0);

        Assert.Equal(6, result);
    }

    [Fact]
    public void LeastInterval_LeetcodeExample3_Returns16()
    {
        // A, A, A, A, A, A, B, C, D, E, F, G with n=2 => 16
        var result = _sut.LeastInterval(['A', 'A', 'A', 'A', 'A', 'A', 'B', 'C', 'D', 'E', 'F', 'G'], 2);

        Assert.Equal(16, result);
    }

    [Fact]
    public void LeastInterval_SingleTask_ReturnOne()
    {
        var result = _sut.LeastInterval(['A'], 5);

        Assert.Equal(1, result);
    }

    [Fact]
    public void LeastInterval_AllSameTasks_NoCooldown_ReturnsCount()
    {
        // A A A A with n=0 => 4
        var result = _sut.LeastInterval(['A', 'A', 'A', 'A'], 0);

        Assert.Equal(4, result);
    }

    [Fact]
    public void LeastInterval_AllSameTasks_WithCooldown_ReturnsCorrect()
    {
        // A A A with n=3 => A _ _ _ A _ _ _ A = 9
        var result = _sut.LeastInterval(['A', 'A', 'A'], 3);

        Assert.Equal(9, result);
    }

    [Fact]
    public void LeastInterval_AllDistinctTasks_NoCooldownNeeded_ReturnsCount()
    {
        // A B C D E with n=2 => no idle needed since all different
        var result = _sut.LeastInterval(['A', 'B', 'C', 'D', 'E'], 2);

        Assert.Equal(5, result);
    }

    [Fact]
    public void LeastInterval_EnoughDiversityToFillCooldown_NoIdle()
    {
        // A A B B C C with n=2 => A B C A B C = 6 (no idle)
        var result = _sut.LeastInterval(['A', 'A', 'B', 'B', 'C', 'C'], 2);

        Assert.Equal(6, result);
    }

    [Fact]
    public void LeastInterval_TwoTasksHighCooldown_ReturnsCorrect()
    {
        // A A B with n=3 => A _ _ _ A B = 6? no: A _ _ _ A B = 6
        // Actually: A B _ _ A _ = 6? Let's compute: maxFreq=2 (A), maxCount=1 (A only)
        // (2-1)*(3+1) + 1 = 5 but total tasks = 3 so max(3,5) = 5
        var result = _sut.LeastInterval(['A', 'A', 'B'], 3);

        Assert.Equal(5, result);
    }

    [Fact]
    public void LeastInterval_HighCooldown_SomeDominantTask_ReturnsFormula()
    {
        // A A A B C with n=3 => A _ _ _ A _ _ _ A = wait, B and C fill
        // A B C _ A _ _ _ A = 9? let's check: (3-1)*(3+1)+1 = 9, tasks=5, max(9,5)=9
        var result = _sut.LeastInterval(['A', 'A', 'A', 'B', 'C'], 3);

        Assert.Equal(9, result);
    }

    [Fact]
    public void LeastInterval_EnoughTasksToFillCooldown_NoIdle()
    {
        // A,C,A,B,D,B with n=1 => A B C A B D = 6 (no idle, enough variety)
        var result = _sut.LeastInterval(['A', 'C', 'A', 'B', 'D', 'B'], 1);

        Assert.Equal(6, result);
    }
}

