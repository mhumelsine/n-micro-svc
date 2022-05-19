using Profile.Core.Aggregates;

namespace Profile.Core.Repositories;

public interface IAggregateRepository<T> 
{
    Task<T> GetAsync(long id);
    Task SaveAsync(T aggregate);
}

public class ProfileRepository : IAggregateRepository<ProfileAggregate>
{
    public Task<ProfileAggregate> GetAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task SaveAsync(ProfileAggregate aggregate)
    {
        throw new NotImplementedException();
    }
}