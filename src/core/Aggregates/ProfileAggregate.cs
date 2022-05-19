using Profile.Core.ValueObjects;
using Profile.Core.Events;

namespace Profile.Core.Aggregates;

public class ProfileAggregate
{
    public long Id { get; set; }
    public Name Name { get; set; }
    public SSN SSN { get; set; }
    public Address Address { get; set; }
    public DateTime DateOfBirth { get; set; }
    public DateTime? DateOfDeath { get; set; }
    public CodedValue Race { get; set; }
    public CodedValue Ethnicity { get; set; }
    public CodedValue Gender { get; set; }

    //TODO aggregate base class

    private ICollection<DomainEvent> unpublishedEvents = new List<DomainEvent>();
    protected void Apply<T>(T @event) where T : DomainEvent
    {
        unpublishedEvents.Add(@event);
        Dispatch(@event);
    }

    public void ChangeAddress(Address address)
    {
        // Make idempontent 
        if (!Address.Equals(address))
        {
            Apply(new AddressChanged(Address, address));
        }
    }

    public void ChangeName(Name name)
    {
        // Make idempontent 
        if (!Name.Equals(name))
        {
            Apply(new NameChanged(Name, name));
        }
    }

    public void ChangeDemographics(
        CodedValue gender,
        CodedValue ethnicity,
        CodedValue race
    )
    {
        bool allSame = Gender.Equals(gender)
            && Race.Equals(race)
            && Ethnicity.Equals(ethnicity);

        if (!allSame)
        {
            Apply(new DemographicsChanged(gender, race, ethnicity));
        }
    }

    public void ChangeDateOfDeath(DateTime? dateOfDeath)
    {
        if (DateOfDeath != dateOfDeath)
        {
            Apply(new DateOfDeathChanged(DateOfDeath, dateOfDeath));
        }
    }


    //this can get distilled down to
    public void Change<TValue, TEvent>(
        TValue value,
        TValue existingValue,
        TEvent @event
    )
    where TEvent : DomainEvent
    {
        if (!existingValue.Equals(value))
        {
            Apply(@event);
        }
    }

    // this is an option instead of a dispatcher
    public void Dispatch<TEvent>(TEvent @event) where TEvent : DomainEvent
    {
        switch (@event)
        {
            case NameChanged nameChanged:
                On(nameChanged);
                return;
            case DateOfDeathChanged dateOfDeathChanged:
                On(dateOfDeathChanged);
                return;
            case DemographicsChanged demographicsChanged:
                On(demographicsChanged);
                return;
            case AddressChanged addressChanged:
                On(addressChanged);
                return;
        }
    }

    // must always provide a state change through an event
    // this is what allows replay
    protected void On(AddressChanged @event)
    {
        Address = @event.NewAddress;
    }

    protected void On(NameChanged @event)
    {
        Name = @event.NewName;
    }

    protected void On(DemographicsChanged @event)
    {
        Race = @event.NewRace;
        Ethnicity = @event.NewEthnicity;
        Gender = @event.NewGender;
    }

    protected void On(DateOfDeathChanged @event)
    {
        DateOfDeath = @event.NewDateOfDeath;
    }
}