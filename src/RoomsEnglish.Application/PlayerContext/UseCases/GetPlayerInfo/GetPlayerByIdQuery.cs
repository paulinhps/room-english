using RoomsEnglish.Application.PlayerContext.ViewModels;
using RoomsEnglish.Application.SharedContext.UseCases;

namespace RoomsEnglish.Application.PlayerContext.UseCases.GetPlayerInfo;
public class GetPlayerByIdQuery : RequestQuery<PlayerViewModel>
{
    public Guid Id { get; init; }
}
