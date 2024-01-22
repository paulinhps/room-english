using FluentValidation;

namespace RoomsEnglish.Application.AccountContext.LoginIn;

public class AuthUserCommandValidator: AbstractValidator<AuthUserCommand> {

    public AuthUserCommandValidator()
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