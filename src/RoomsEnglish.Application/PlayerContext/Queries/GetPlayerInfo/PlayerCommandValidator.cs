using FluentValidation;

namespace RoomsEnglish.Application.PlayerContext.PlayerGetId;

public class PlayerCommandValidator : AbstractValidator<PlayerCommand>
{
    public PlayerCommandValidator()
    {
        RuleFor(player => player.Id)
            .NotEmpty()
            .WithMessage("Id is required");
    }
}