using RoomsEnglish.Domain.PlayerContext.Entities;

namespace RoomsEnglish.Domain.PlayerContext.Repositories;

public interface IPlayerRepository
{
    Task<Player> FindPlayerByIdAsync(Guid playerId, CancellationToken cancellationToken);
    Task<Player> GetPlayersAsync(CancellationToken cancellationToken);
}
