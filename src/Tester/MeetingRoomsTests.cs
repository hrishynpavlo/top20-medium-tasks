using TaskRunner;

namespace Tester;

public class MeetingRoomsTests
{
    private readonly MeetingRooms _sut = new();

    [Fact]
    public void MinMeetingRooms_LeetcodeExample1_Returns2()
    {
        // [[0,30],[5,10],[15,20]] => 2 rooms
        var result = _sut.MinMeetingRooms([[0, 30], [5, 10], [15, 20]]);

        Assert.Equal(2, result);
    }

    [Fact]
    public void MinMeetingRooms_LeetcodeExample2_Returns1()
    {
        // [[7,10],[2,4]] => 1 room (no overlap)
        var result = _sut.MinMeetingRooms([[7, 10], [2, 4]]);

        Assert.Equal(1, result);
    }

    [Fact]
    public void MinMeetingRooms_NoMeetings_Returns0()
    {
        var result = _sut.MinMeetingRooms([]);

        Assert.Equal(0, result);
    }

    [Fact]
    public void MinMeetingRooms_SingleMeeting_Returns1()
    {
        var result = _sut.MinMeetingRooms([[5, 10]]);

        Assert.Equal(1, result);
    }

    [Fact]
    public void MinMeetingRooms_AllOverlapping_ReturnsCount()
    {
        // [[1,10],[2,9],[3,8],[4,7]] => 4 rooms (all overlap)
        var result = _sut.MinMeetingRooms([[1, 10], [2, 9], [3, 8], [4, 7]]);

        Assert.Equal(4, result);
    }

    [Fact]
    public void MinMeetingRooms_NoOverlap_Returns1()
    {
        // [[1,2],[3,4],[5,6]] => 1 room (sequential)
        var result = _sut.MinMeetingRooms([[1, 2], [3, 4], [5, 6]]);

        Assert.Equal(1, result);
    }

    [Fact]
    public void MinMeetingRooms_EndEqualsStart_NotOverlapping_Returns1()
    {
        // [[1,5],[5,10]] => 1 room (end == start is not overlap)
        var result = _sut.MinMeetingRooms([[1, 5], [5, 10]]);

        Assert.Equal(1, result);
    }

    [Fact]
    public void MinMeetingRooms_ComplexCase_Returns3()
    {
        // [[1,4],[2,5],[3,6],[7,9]] => 3 rooms
        var result = _sut.MinMeetingRooms([[1, 4], [2, 5], [3, 6], [7, 9]]);

        Assert.Equal(3, result);
    }

    [Fact]
    public void MinMeetingRooms_UnsortedInput_ReturnsCorrect()
    {
        // [[13,15],[1,13],[6,9]] => 1 room (no overlap after sorting)
        var result = _sut.MinMeetingRooms([[13, 15], [1, 13], [6, 9]]);

        Assert.Equal(2, result);
    }
}

