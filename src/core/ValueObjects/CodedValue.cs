using System.Linq;

namespace Profile.Core.ValueObjects;

public class CodedValue
{
    public readonly string Code;
    public readonly string Description;
    public readonly int Id;

    public CodedValue(string code, string description, int id)
    {
        Code = code;
        Description = description;
        Id = id;
    }
}