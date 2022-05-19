namespace Profile.Core.Events;

public class DateOfDeathChanged : DomainEvent
{
    public readonly DateTime? PreviousDateOfDeath;
    public readonly DateTime? NewDateOfDeath;

    public DateOfDeathChanged(DateTime? previousDateOfDeath, DateTime? newDateOfDeath)
    {
        PreviousDateOfDeath = previousDateOfDeath;
        NewDateOfDeath = newDateOfDeath;
    }
}