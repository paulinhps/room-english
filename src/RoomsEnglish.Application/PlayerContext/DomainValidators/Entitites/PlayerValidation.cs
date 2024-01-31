using FluentValidation;
using RoomsEnglish.Domain.SharedContext.ValueObjects;
using RoomsEnglish.Domain.UserContext.Entities;

namespace RoomsEnglish.Application.PlayerContext.DomainValidators.Entitites;

public class PlayerValidation : AbstractValidator<Player>
{
    public PlayerValidation(IValidator<Email> emailValidator)
    {
        RuleFor(player => player.Id)
            .NotNull();

        RuleFor(player => player.Name)
            .NotNull();

        RuleFor(player => player.Email)
        .NotNull()
        .SetValidator(emailValidator);

        RuleFor(player => player.Password)
            .NotEmpty();
    }
}
