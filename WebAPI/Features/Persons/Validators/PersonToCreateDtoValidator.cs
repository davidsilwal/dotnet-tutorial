using FluentValidation;

namespace WebAPI.Features.Persons.Validators;


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