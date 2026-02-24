using Sqids;

namespace Idea.Common;

public struct IdeaEntry
{ 
    private static readonly SqidsEncoder<long> _Encoder = new();

    /// <summary>
    /// 
    /// </summary>
    /// <param name="creationDate"></param>
    /// <param name="initialName"></param>
    /// <returns>An ID string</returns>
    public static string GenerateID(DateTime creationDate, string initialName)
    {
        
        return $"{_Encoder.Encode(creationDate.Ticks)}-{initialName}";
    }
}