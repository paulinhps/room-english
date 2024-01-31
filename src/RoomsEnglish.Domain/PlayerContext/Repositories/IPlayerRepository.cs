using RoomsEnglish.Domain.UserContext.Entities;

namespace RoomsEnglish.Domain.AccountContext.Repositories;

public interface IPlayerRepository
{
    Task<Player> CreatePlayerAsync(Player user);
    Task<bool> ExistsPlayerWithEmailAsync(string email);
    Task<Player?> FindPlayerByIdAsync(Guid playerId, CancellationToken cancellationToken);
    Task<IApplicationUser?> FindPlayerByEmailAsync(string userEmail, CancellationToken cancellationToken);

}
