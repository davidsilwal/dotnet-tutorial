using Entities.Persons;
using Infrastructure.Data;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QueryKit;
using WebAPI.Features.Persons.Dtos;

namespace WebAPI.Controllers;


[ApiController]
[Route("[controller]")]
public class PersonsController(ApplicationDbContext dbContext) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyList<PersonDto>), 200)]
    public async Task<ActionResult<IReadOnlyList<PersonDto>>> ListAllAsync([FromQuery] PersonQueryParameters queryParameters)
    {
        var query = dbContext.Persons
            .ApplyQueryKitFilter(queryParameters.Filter ?? string.Empty)
            .ApplyQueryKitSort(queryParameters.Sort ?? string.Empty)
            .ProjectToType<PersonDto>();

        var result = await PaginatedList<PersonDto>
            .CreateAsync(query, queryParameters.Page, queryParameters.PageSize);

        return Ok(result);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(404)]
    [ProducesResponseType(typeof(PersonDto), 200)]
    public async Task<ActionResult<PersonDto>> GetByIdAsync(int id)
    {
        var query = dbContext.Persons;
        var result = await query.FirstOrDefaultAsync(x => x.Id == id);

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
        var entity = new Person
        {
            Name = dto.Name,
            Email = dto.Email,
            Phone = dto.Phone,
            Address = dto.Address
        };

        dbContext.Persons.Add(entity);
        await dbContext.SaveChangesAsync();

        return CreatedAtRoute(new { id = entity.Id }, entity);
    }

    [HttpPatch("{id}")]
    [ProducesResponseType(404)]
    [ProducesResponseType(typeof(PersonDto), 200)]
    public async Task<ActionResult<PersonDto>> UpdateAsync(int id, PersonToUpdateDto dto)
    {
        var entity = await dbContext.Persons.FirstOrDefaultAsync(x => x.Id == id);
        if (entity == null)
        {
            return NotFound();
        }

        entity.Name = dto.Name;
        entity.Email = dto.Email;
        entity.Phone = dto.Phone;
        entity.Address = dto.Address;

        await dbContext.SaveChangesAsync();
        return Ok(entity);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(404)]
    [ProducesResponseType(204)]
    public async Task<ActionResult> DeleteAsync(int id)
    {
        var entity = await dbContext.Persons.FirstOrDefaultAsync(x => x.Id == id);
        if (entity == null)
        {
            return NotFound();
        }

        dbContext.Persons.Remove(entity);
        await dbContext.SaveChangesAsync();
        return NoContent();
    }
}