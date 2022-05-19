using Profile.Core.ValueObjects;

namespace Profile.Core.Events;

public class DemographicsChanged : DomainEvent
{
    public CodedValue NewGender { get; set; }
    public CodedValue NewRace { get; set; }
    public CodedValue NewEthnicity { get; set; }

    public DemographicsChanged(CodedValue newGender, CodedValue newRace, CodedValue newEthnicity)
    {
        NewGender = newGender;
        NewRace = newRace;
        NewEthnicity = newEthnicity;
    }
}