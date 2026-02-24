namespace Idea.Tests.Common;

using Idea.Common;

public class IdeaEntryTests
{
    public static IEnumerable<object[]> GenerateID_EqualParams_EqualID_Data =>
        new List<object[]>
        {
            new object[] {new DateTime(new DateOnly(1,1,1), new TimeOnly(0, 0, 0)), "idea"},
            new object[] {new DateTime(new DateOnly(2022,6,12), new TimeOnly(8, 30, 55)), "idea"},
            new object[] {new DateTime(new DateOnly(1967,12,5), new TimeOnly(18, 13, 42)), "idea"},
            new object[] {new DateTime(new DateOnly(9999,7,24), new TimeOnly(22, 52, 2)), "idea"},
        };
    
    /// <summary>
    /// Generates two IdeaEntry IDs with the same parameters, assert that they are the same.
    /// </summary>
    /// <param name="creationDateTime"></param>
    /// <param name="initialName"></param>
    [Theory]
    [MemberData(nameof(GenerateID_EqualParams_EqualID_Data))]
    public void GenerateID_EqualParams_EqualID(DateTime creationDateTime, string initialName)
    {
        var ID1 = IdeaEntry.GenerateID(creationDateTime, initialName);
        var ID2 = IdeaEntry.GenerateID(creationDateTime, initialName);
        Assert.Equal(ID1, ID2);
    }

    public static IEnumerable<object[]> GenerateID_DiffParams_DiffID_Data =>
        new List<object[]>
        {
            new object[] {new DateTime(new DateOnly(2,1,1), new TimeOnly(0, 0, 0)), "idea",
                new DateTime(new DateOnly(1,1,1), new TimeOnly(0, 0, 0)), "idea"},
            new object[] {new DateTime(new DateOnly(1,3,1), new TimeOnly(0, 0, 0)), "idea",
                new DateTime(new DateOnly(1,1,1), new TimeOnly(0, 0, 0)), "idea"},
            new object[] {new DateTime(new DateOnly(1,1,9), new TimeOnly(0, 0, 0)), "idea",
                new DateTime(new DateOnly(1,1,1), new TimeOnly(0, 0, 0)), "idea"},
            new object[] {new DateTime(new DateOnly(3,4,5), new TimeOnly(0, 0, 0)), "idea",
                new DateTime(new DateOnly(6,4,8), new TimeOnly(0, 0, 0)), "idea"},
            new object[] {new DateTime(new DateOnly(1,1,1), new TimeOnly(12, 12, 24)), "idea",
                new DateTime(new DateOnly(1,1,1), new TimeOnly(12, 13, 25)), "idea"},
            new object[] {new DateTime(new DateOnly(1,1,1), new TimeOnly(0, 0, 0)), "idea",
                new DateTime(new DateOnly(1,1,1), new TimeOnly(0, 0, 0)), "not-idea"},
        };
    

    /// <summary>
    /// Generate two IdeaEntry IDs with the different parameters, assert that they are different.
    /// </summary>
    /// <param name="creationDateTime1"></param>
    /// <param name="initialName1"></param>
    /// <param name="creationDateTime2"></param>
    /// <param name="initialName2"></param>
    [Theory]
    [MemberData(nameof(GenerateID_DiffParams_DiffID_Data))]
    public void GenerateID_DiffParams_DiffID(DateTime creationDateTime1, string initialName1, DateTime creationDateTime2, string initialName2)
    {
        var ID1 = IdeaEntry.GenerateID(creationDateTime1, initialName1);
        var ID2 = IdeaEntry.GenerateID(creationDateTime2, initialName2);
        Assert.NotEqual(ID1, ID2);
    }
}
