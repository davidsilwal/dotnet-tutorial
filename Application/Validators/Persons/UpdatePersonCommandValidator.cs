using Application.Features.Persons;
using FluentValidation;

namespace Application.Validators.Persons;

public class UpdatePersonCommandValidator : AbstractValidator<UpdatePersonCommand>
{
    public UpdatePersonCommandValidator()
    {
        RuleFor(x => x.PersonToUpdate.Name).NotEmpty();
        RuleFor(x => x.PersonToUpdate.Email).NotEmpty().EmailAddress();
        RuleFor(x => x.PersonToUpdate.Phone).NotEmpty();
        RuleFor(x => x.PersonToUpdate.Address).NotEmpty();
    }
}
