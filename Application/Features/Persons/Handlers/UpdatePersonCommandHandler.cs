using Application.Shared.Dtos.Persons;
using Infrastructure.Persistence;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WebAPI.Features.Persons;

namespace Application.Features.Persons.Handlers;

public class UpdatePersonCommandHandler : IRequestHandler<UpdatePersonCommand, PersonDto>
{
    private readonly ApplicationDbContext dbContext;

    public UpdatePersonCommandHandler(ApplicationDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<PersonDto> Handle(UpdatePersonCommand request, CancellationToken cancellationToken)
    {
        var entity = await dbContext.Persons.FirstOrDefaultAsync(x => x.Id == request.Id);
        if (entity == null)
        {
            throw new Exception("Entity not found");
        }

        entity.Name = request.PersonToUpdate.Name;
        entity.Email = request.PersonToUpdate.Email;
        entity.Phone = request.PersonToUpdate.Phone;
        entity.Address = request.PersonToUpdate.Address;

        await dbContext.SaveChangesAsync();
        return entity.Adapt<PersonDto>();
    }

}
