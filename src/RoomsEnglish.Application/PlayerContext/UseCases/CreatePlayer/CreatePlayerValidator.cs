using FluentValidation;

using RoomsEnglish.Application.PlayerContext.UseCases.CreatePlayer;

namespace RoomsEnglish.Application.PlayerContext.UseCases.LoginPlayer;

public class CreatePlayerValidator : AbstractValidator<CreatePlayerCommand>
{

    public CreatePlayerValidator()
    {

        RuleFor(createCommand => createCommand.Name)
        .NotEmpty()
        .WithMessage("name is required")
        .MaximumLength(50)
        .WithMessage("required maximum of 80 caracteres");

        RuleFor(auth => auth.Email)
        .NotEmpty()
        .WithMessage("email is required")
        .EmailAddress();

        RuleFor(auth => auth.Password)
        .NotEmpty()
        .WithMessage("password is required");

    }
}