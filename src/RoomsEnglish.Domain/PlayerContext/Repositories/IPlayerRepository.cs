using RoomsEnglish.Domain.UserContext.Entities;

namespace RoomsEnglish.Domain.AccountContext.Repositories;

public interface IPlayerRepository
{
    Task<Player> FindPlayerById(Guid playerId, CancellationToken cancellationToken);

}
