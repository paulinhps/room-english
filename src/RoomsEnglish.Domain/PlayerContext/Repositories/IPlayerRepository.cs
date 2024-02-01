using RoomsEnglish.Domain.PlayerContext.Entities;
namespace RoomsEnglish.Domain.PlayerContext.Repositories;
public interface IPlayerRepository
{
    Task<Player> CreatePlayerAsync(Player user);
    Task<bool> ExistsPlayerWithEmailAsync(string email);
    Task<Player?> FindPlayerByIdAsync(Guid playerId, CancellationToken cancellationToken);
    Task<IApplicationUser?> FindPlayerByEmailAsync(string userEmail, CancellationToken cancellationToken);
    Task<Player> GetPlayersAsync(CancellationToken cancellationToken);
}
