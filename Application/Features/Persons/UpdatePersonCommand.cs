using Application.Shared.Dtos.Persons;
using MediatR;

namespace Application.Features.Persons;

public class UpdatePersonCommand : IRequest<PersonDto>
{
    public PersonToUpdateDto PersonToUpdate { get; set; } = null!;
    public int Id { get; set; }
}
