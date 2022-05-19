using Profile.Core.ValueObjects;
using Profile.Core.Events;

namespace Profile.Core.Aggregates;

public class ProfileAggregateReducer
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

    //only issue with this is 
    protected static void Reduce<TEvent>(ProfileAggregateReducer aggregate, TEvent @event)
        where TEvent : DomainEvent
    {
        switch (@event)
        {
            case NameChanged nameChanged:
                aggregate.Name = nameChanged.NewName;
                return;
            case DateOfDeathChanged dateOfDeathChanged:
                aggregate.DateOfDeath = dateOfDeathChanged.NewDateOfDeath;
                return;
            case DemographicsChanged demographicsChanged:
                aggregate.Gender = demographicsChanged.NewGender;
                aggregate.Race = demographicsChanged.NewRace;
                aggregate.Ethnicity = demographicsChanged.NewEthnicity;
                return;
            case AddressChanged addressChanged:
                aggregate.Address = addressChanged.NewAddress;
                return;
        }
    }

    private ICollection<DomainEvent> unpublishedEvents = new List<DomainEvent>();
    protected void Dispatch<T>(T @event) where T : DomainEvent
    {
        unpublishedEvents.Add(@event);
        Reduce(this, @event);
    }

    //these would be like action creators
    public void ChangeAddress(Address address)
    {
        // Make idempontent 
        if (!Address.Equals(address))
        {
            Dispatch(new AddressChanged(Address, address));
        }
    }

    public void ChangeName(Name name)
    {
        // Make idempontent 
        if (!Name.Equals(name))
        {
            Dispatch(new NameChanged(Name, name));
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
            Dispatch(new DemographicsChanged(gender, race, ethnicity));
        }
    }

    public void ChangeDateOfDeath(DateTime? dateOfDeath)
    {
        if (DateOfDeath != dateOfDeath)
        {
            Dispatch(new DateOfDeathChanged(DateOfDeath, dateOfDeath));
        }
    }
}