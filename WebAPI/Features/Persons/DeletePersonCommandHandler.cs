using Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Features.Persons;

public class DeletePersonCommandHandler : IRequestHandler<DeletePersonCommand, Unit>
{
    private readonly ApplicationDbContext dbContext;

    public DeletePersonCommandHandler(ApplicationDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<Unit> Handle(DeletePersonCommand request, CancellationToken cancellationToken)
    {
        var entity = await dbContext.Persons.FirstOrDefaultAsync(x => x.Id == request.Id);
        if (entity == null)
        {
            throw new Exception("Entity not found");
        }

        dbContext.Persons.Remove(entity);
        await dbContext.SaveChangesAsync();
        return Unit.Value;
    }
}
