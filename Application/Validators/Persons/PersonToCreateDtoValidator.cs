using Application.Features.Persons;
using FluentValidation;

namespace Application.Validators.Persons;


public class CreatePersonCommandValidator : AbstractValidator<CreatePersonCommand>
{
    public CreatePersonCommandValidator()
    {
        RuleFor(x => x.PersonToCreate.Name).NotEmpty();
        RuleFor(x => x.PersonToCreate.Email).NotEmpty().EmailAddress();
        RuleFor(x => x.PersonToCreate.Phone).NotEmpty();
        RuleFor(x => x.PersonToCreate.Address).NotEmpty();
    }
}