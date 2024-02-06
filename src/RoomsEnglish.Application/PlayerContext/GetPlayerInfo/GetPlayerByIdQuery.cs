using MediatR;
using RoomsEnglish.Application.PlayerContext.ViewModels;

namespace RoomsEnglish.Application.PlayerContext.GetPlayerInfo;
public class GetPlayerByIdQuery : IRequest<QueryResult<PlayerViewModel>>
{
    public Guid Id { get; init; }
}
