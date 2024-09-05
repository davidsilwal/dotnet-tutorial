using Application.Shared.Dtos.Persons;
using Refit;

namespace BlazorUI;

public interface IPersonApi
{
    [Get("/PersonsV2")]
    Task<IReadOnlyList<PersonDto>> GetPersonsAsync();

    [Get("/PersonsV2/{id}")]
    Task<PersonDto> GetPersonByIdAsync(int id);

    [Post("/PersonsV2")]
    Task<PersonDto> CreatePersonAsync([Body] PersonToCreateDto createPersonCommand);

    [Patch("/PersonsV2/{id}")]
    Task UpdatePersonAsync(int id, [Body] PersonToUpdateDto updatePersonCommand);

    [Delete("/PersonsV2/{id}")]
    Task DeletePersonAsync(int id);
}