using MediatR;
using WebAPI.Features.Persons.Dtos;

namespace WebAPI.Features.Persons;

public class ListAllPersonsQuery : IRequest<IReadOnlyList<PersonDto>>
{
}
