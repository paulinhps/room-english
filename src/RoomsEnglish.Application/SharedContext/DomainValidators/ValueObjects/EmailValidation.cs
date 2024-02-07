using FluentValidation;

using RoomsEnglish.Domain.SharedContext.ValueObjects;

namespace RoomsEnglish.Application.SharedContext.DomainValidators.ValueObjects;

public class EmailValidation : AbstractValidator<Email>
{
    public EmailValidation()
    {
        RuleFor(email => email.Address)
        .NotEmpty()
        .EmailAddress();
    }
}
