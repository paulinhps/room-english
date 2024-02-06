using FluentValidation;

namespace RoomsEnglish.Application.PlayerContext.UseCases.GetPlayers;

public class GetPlayersCommandValidator : AbstractValidator<GetPlayersQuery>
{
    public GetPlayersCommandValidator() { }
}