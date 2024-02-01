using FluentValidation;

namespace RoomsEnglish.Application.PlayerContext.UseCases.LoginPlayer;

public class LoginCommandValidator : AbstractValidator<LoginPlayerCommand>
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