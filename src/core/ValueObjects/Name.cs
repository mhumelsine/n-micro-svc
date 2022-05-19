namespace Profile.Core.ValueObjects;

public class Name
{
    public readonly string First;
    public readonly string? Middle;
    public readonly string Last;
    public readonly string? Suffix;
    public readonly string? Madien;
    public readonly string DisplayName;

    public Name(
        string first, 
        string? middle, 
        string last, 
        string? suffix = null, 
        string? madien = null
    )
    {
        First = first;
        Middle = middle;
        Last = last;
        Suffix = suffix;
        Madien = madien;
        DisplayName = $"{Last}, {First} {Middle} {Suffix}";
    }
}