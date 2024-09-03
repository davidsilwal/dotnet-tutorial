using Entities.Persons;
using Infrastructure.Data;
using Mapster;
using MediatR;
using WebAPI.Features.Persons.Dtos;

namespace WebAPI.Features.Persons;

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
