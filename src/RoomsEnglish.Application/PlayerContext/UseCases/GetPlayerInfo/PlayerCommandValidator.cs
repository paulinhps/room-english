using FluentValidation;

namespace RoomsEnglish.Application.PlayerContext.UseCases.GetPlayerInfo;

public class GetPlayerByIdQueryValidator : AbstractValidator<GetPlayerByIdQuery>
{
    public GetPlayerByIdQueryValidator()
    {
        RuleFor(player => player.Id)
            .NotEmpty()
            .WithMessage("Id is required");
    }
}
