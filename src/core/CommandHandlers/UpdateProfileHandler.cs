using MassTransit;
using Profile.Core.Aggregates;
using Profile.Core.Commands;
using Profile.Core.Events;
using Profile.Core.Repositories;

namespace Profile.Core.CommandHandlers;

public class UpdateProfileCommandHandler : IConsumer<UpdateProfile>
{
    private readonly IAggregateRepository<ProfileAggregate> repo;

    public UpdateProfileCommandHandler(IAggregateRepository<ProfileAggregate> repo)
    {
        this.repo = repo;
    }
    public async Task Consume(ConsumeContext<UpdateProfile> context)
    {
        var command = context.Message;

        var aggregate = await repo.GetAsync(command.Id);

        aggregate.ChangeAddress(command.Address);
        aggregate.ChangeName(command.Name);
        aggregate.ChangeDemographics(command.GenderCode, command.RaceCode, command.EthnicityCode);
        aggregate.ChangeDateOfDeath(command.DateOfDeath);

    }
}