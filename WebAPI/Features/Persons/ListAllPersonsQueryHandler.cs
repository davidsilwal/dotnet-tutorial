using Infrastructure.Data;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WebAPI.Features.Persons.Dtos;

namespace WebAPI.Features.Persons;

public class ListAllPersonsQueryHandler : IRequestHandler<ListAllPersonsQuery, IReadOnlyList<PersonDto>>
{
    private readonly ApplicationDbContext dbContext;

    public ListAllPersonsQueryHandler(ApplicationDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<IReadOnlyList<PersonDto>> Handle(ListAllPersonsQuery request, CancellationToken cancellationToken)
    {
        var entities = await dbContext.Persons.ToListAsync();
        return entities.Adapt<IReadOnlyList<PersonDto>>();
    }
}