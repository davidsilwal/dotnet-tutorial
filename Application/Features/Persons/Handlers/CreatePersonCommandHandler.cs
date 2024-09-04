using Application.Shared.Dtos.Persons;
using Domain.Entities;
using Infrastructure.Persistence;
using Mapster;
using MediatR;

namespace Application.Features.Persons.Handlers;

public class CreatePersonCommandHandler : IRequestHandler<CreatePersonCommand, PersonDto>
{
    private readonly ApplicationDbContext dbContext;

    public CreatePersonCommandHandler(ApplicationDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<PersonDto> Handle(CreatePersonCommand request, CancellationToken cancellationToken)
    {

        var entity = request.PersonToCreate.Adapt<Person>();

        dbContext.Persons.Add(entity);
        await dbContext.SaveChangesAsync();

        return entity.Adapt<PersonDto>();
    }
}
