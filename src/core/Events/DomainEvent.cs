namespace Profile.Core.Events;

public class DomainEvent
{
    public long Id { get; set; }
    public DateTime Timestamp { get; set; }
}