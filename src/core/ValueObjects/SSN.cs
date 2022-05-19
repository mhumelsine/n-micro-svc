using System.Linq;

namespace Profile.Core.ValueObjects;

public class SSN
{
    public string LastFour => ssn.Substring(ssn.Length - 4);
    public string Masked => $"***-**-{LastFour}";

    private readonly string ssn;

    public SSN(string ssn)
    {
        this.ssn = ssn;
    }
}