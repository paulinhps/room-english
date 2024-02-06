using RoomsEnglish.Application.PlayerContext.ViewModels;
using RoomsEnglish.Application.SharedContext.UseCases;

namespace RoomsEnglish.Application.PlayerContext.UseCases.GetPlayers;
public class GetPlayersQuery : RequestQuery<IEnumerable<PlayerViewModel>> { }