using Infrastructure.Data;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WebAPI.Features.Persons.Dtos;

namespace WebAPI.Features.Persons;

public class GetPersonByIdQueryHandler : IRequestHandler<GetPersonByIdQuery, PersonDto>
{
    private readonly ApplicationDbContext dbContext;

    public GetPersonByIdQueryHandler(ApplicationDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<PersonDto> Handle(GetPersonByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await dbContext.Persons.FirstOrDefaultAsync(x => x.Id == request.Id);
        if (entity == null)
        {
            throw new Exception("Entity not found");
        }

        return entity.Adapt<PersonDto>();
    }
}
