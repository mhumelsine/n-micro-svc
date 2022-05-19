using Profile.Core.ValueObjects;

namespace Profile.Core.Events;

public class AddressChanged : DomainEvent
{
    public readonly Address PreviousAddress;
    public readonly Address NewAddress;

    public AddressChanged(Address previousAddress, Address newAddress)
    {
        PreviousAddress = previousAddress;
        NewAddress = newAddress;
    }
}