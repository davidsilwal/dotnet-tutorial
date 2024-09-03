using MediatR;
using WebAPI.Features.Persons.Dtos;

namespace WebAPI.Features.Persons;

public class CreatePersonCommand : IRequest<PersonDto>
{
    public PersonToCreateDto PersonToCreate { get; set; } = null!;
}
