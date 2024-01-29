using RoomsEnglish.Domain.UserContext.Entities;

namespace RoomsEnglish.Domain.AccountContext.Repositories;

public interface IPlayerRepository
{
    Task<ApplicationUser> CreatePlayer(ApplicationUser user);
    Task<bool> ExistsPlayerWithEmail(string email);
    Task<Player> FindPlayerById(Guid playerId, CancellationToken cancellationToken);

}
