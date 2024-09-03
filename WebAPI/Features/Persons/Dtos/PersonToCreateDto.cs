namespace WebAPI.Features.Persons.Dtos;

public class PersonToCreateDto
{
    public string Name { get; set; } = null!;

    [IgnoreLoggable]
    public string Email { get; set; } = null!;
    public string Phone { get; set; } = null!;
    public string Address { get; set; } = null!;
}
