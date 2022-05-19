using Profile.Core.ValueObjects;

namespace Profile.Core.Commands;

public class CreateProfile
{
    public Name Name { get; set; }
    public SSN SSN { get; set; }
    public Address Address { get; set; }
    public DateTime DateOfBirth { get; set; }
    public DateTime? DateOfDeath { get; set; }
    public CodedValue RaceCode { get; set; }
    public CodedValue EthnicityCode { get; set; }
    public CodedValue GenderCode { get; set; }
    
    
}