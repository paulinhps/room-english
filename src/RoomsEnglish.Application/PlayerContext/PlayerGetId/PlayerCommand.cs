using MediatR;

namespace RoomsEnglish.Application.PlayerContext.PlayerGetId;
public class PlayerCommand : IRequest<PlayerResult>
{
    public Guid Id { get; set; }
}
