using FluentValidation;

namespace RoomsEnglish.Application.PlayerContext.GetPlayers;

public class GetPlayersCommandValidator : AbstractValidator<GetPlayersQuery>
{
    public GetPlayersCommandValidator() { }
}