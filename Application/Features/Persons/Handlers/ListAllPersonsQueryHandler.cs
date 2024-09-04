using Application.Shared.Dtos.Persons;
using Infrastructure.Persistence;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Persons.Handlers;

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