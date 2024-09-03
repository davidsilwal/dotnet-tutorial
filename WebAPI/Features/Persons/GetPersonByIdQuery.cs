using MediatR;
using WebAPI.Features.Persons.Dtos;

namespace WebAPI.Features.Persons;


public class GetPersonByIdQuery : IRequest<PersonDto>
{
    public int Id { get; set; }
}
