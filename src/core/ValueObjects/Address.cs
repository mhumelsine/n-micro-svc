using System.Linq;

namespace Profile.Core.ValueObjects;

public class Address
{
    public readonly string Street1;
    public readonly string Street2;
    public readonly string City;
    public readonly string State;
    public readonly string Zip;

    public Address(
        string street1, 
        string street2, 
        string city, 
        string state, 
        string zip
    )
    {
        Street1 = street1;
        Street2 = street2;
        City = city;
        State = state;
        Zip = zip;
    }
}