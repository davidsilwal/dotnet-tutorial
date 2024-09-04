using Application.Shared.Dtos.Persons;
using MediatR;

namespace Application.Features.Persons;

public class CreatePersonCommand : IRequest<PersonDto>
{
    public PersonToCreateDto PersonToCreate { get; set; } = null!;
}
