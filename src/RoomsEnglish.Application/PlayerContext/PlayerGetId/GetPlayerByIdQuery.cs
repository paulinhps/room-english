using MediatR;
using RoomsEnglish.Application.PlayerContext.ViewModels;

namespace RoomsEnglish.Application.PlayerContext.PlayerGetId;
public class GetPlayerByIdQuery : IRequest<QueryResult<PlayerViewModel>>
{
    public Guid Id { get; set; }
}
