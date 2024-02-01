using FluentValidation;

namespace RoomsEnglish.Application.PlayerContext.GetPlayerInfo;

public class GetPlayerByIdQueryValidator : AbstractValidator<GetPlayerByIdQuery>
{
    public GetPlayerByIdQueryValidator()
    {
        RuleFor(player => player.Id)
            .NotEmpty()
            .WithMessage("Id is required");
    }
}