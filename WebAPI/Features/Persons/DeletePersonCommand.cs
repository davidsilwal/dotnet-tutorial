using MediatR;

namespace WebAPI.Features.Persons;

public class DeletePersonCommand : IRequest<Unit>
{
    public int Id { get; set; }
}
