using FluentValidation;

namespace RoomsEnglish.Application.PlayerContext.LoginPlayer;

public class LoginCommandValidator : AbstractValidator<LoginCommand>
{

    public LoginCommandValidator()
    {

        RuleFor(auth => auth.Username)
        .NotEmpty()
        .WithMessage("username is required")
        .EmailAddress();

        RuleFor(auth => auth.Password)
        .NotEmpty()
        .WithMessage("password is required");

    }
}