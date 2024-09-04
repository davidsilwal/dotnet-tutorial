using MediatR;

namespace Application.Features.Persons;

public class DeletePersonCommand : IRequest<Unit>
{
   
    public int Id { get; set; }
}
