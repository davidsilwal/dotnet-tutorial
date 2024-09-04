using Application.Shared.Dtos.Persons;
using MediatR;

namespace Application.Features.Persons;

public class ListAllPersonsQuery : IRequest<IReadOnlyList<PersonDto>>
{
}
