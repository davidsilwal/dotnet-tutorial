using MediatR;
using WebAPI.Features.Persons.Dtos;

namespace WebAPI.Features.Persons;

public class UpdatePersonCommand : IRequest<PersonDto>
{
    public PersonToUpdateDto PersonToUpdate { get; set; } = null!;
    public int Id { get; internal set; }
}
