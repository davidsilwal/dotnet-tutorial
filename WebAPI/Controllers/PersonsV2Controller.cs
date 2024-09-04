using Application.Features.Persons;
using Application.Shared.Dtos.Persons;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class PersonsV2Controller(IMediator mediator) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyList<PersonDto>), 200)]
    public async Task<ActionResult<IReadOnlyList<PersonDto>>> ListAllAsync()
    {
        var query = new ListAllPersonsQuery();
        var result = await mediator.Send(query);

        return Ok(result);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(404)]
    [ProducesResponseType(typeof(PersonDto), 200)]
    public async Task<ActionResult<PersonDto>> GetByIdAsync(int id)
    {
        var query = new GetPersonByIdQuery { Id = id };
        var result = await mediator.Send(query);

        if (result == null)
        {
            return NotFound();
        }

        return Ok(result);
    }

    [HttpPost]
    [ProducesResponseType(typeof(PersonDto), 201)]
    public async Task<ActionResult<PersonDto>> CreateAsync(PersonToCreateDto dto)
    {
        var command = new CreatePersonCommand { PersonToCreate = dto };
        var result = await mediator.Send(command);

        return CreatedAtRoute(new { id = result.Id }, result);
    }


    [HttpPatch("{id}")]
    [ProducesResponseType(404)]
    [ProducesResponseType(typeof(PersonDto), 200)]
    public async Task<ActionResult<PersonDto>> UpdateAsync(int id, [FromBody] PersonToUpdateDto dto)
    {
        var command = new UpdatePersonCommand { Id = id, PersonToUpdate = dto };
        var result = await mediator.Send(command);

        if (result == null)
        {
            return NotFound();
        }

        return Ok(result);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(404)]
    public async Task<ActionResult> DeleteAsync(int id)
    {
        var command = new DeletePersonCommand { Id = id };
        var result = await mediator.Send(command);

        return result == null ? NotFound() : NoContent();
    }

}