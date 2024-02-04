using MediatR;
using RoomsEnglish.Application.PlayerContext.ViewModels;

namespace RoomsEnglish.Application.PlayerContext.GetPlayers;
public class GetPlayersQuery : IRequest<QueryResult<IEnumerable<PlayerViewModel>>> { }
