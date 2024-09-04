using Application.Shared.Dtos.Persons;
using MediatR;

namespace Application.Features.Persons;


public class GetPersonByIdQuery : IRequest<PersonDto>
{
    public int Id { get; set; }
}
