using Sqids;

namespace Idea.Common;

public struct IdeaEntry
{ 
    private static readonly SqidsEncoder<long> _Encoder = new();

    public DateTime creationDateTime;
    public string name;

    public string ID;

    public IdeaEntry(DateTime creationDateTime, string initialName)
    {
        this.ID = GenerateID(creationDateTime, initialName);
        this.creationDateTime = creationDateTime;
        this.name = initialName;
    }

    /// <summary>
    /// Generates an IdeaEntry ID based on the given parameters
    /// </summary>
    /// <param name="creationDate"></param>
    /// <param name="initialName"></param>
    /// <returns>An ID string</returns>
    public static string GenerateID(DateTime creationDateTime, string initialName)
    {
        return $"{_Encoder.Encode(creationDateTime.Ticks)}-{initialName}";
    }
    
}