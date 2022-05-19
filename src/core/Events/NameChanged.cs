using Profile.Core.ValueObjects;

namespace Profile.Core.Events;

public class NameChanged : DomainEvent
{
    public readonly Name PreviousName;
    public readonly Name NewName;

    public NameChanged(Name previousName, Name newName)
    {
        PreviousName = previousName;
        NewName = newName;
    }
}