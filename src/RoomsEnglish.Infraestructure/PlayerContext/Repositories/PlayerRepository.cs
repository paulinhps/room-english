using RoomsEnglish.Domain.PlayerContext.Entities;
using RoomsEnglish.Domain.PlayerContext.Repositories;

namespace RoomsEnglish.Infraestructure.PlayerContext.Repositories;

public class PlayerRepository : IPlayerRepository
{
    public Task<Player> FindPlayerByIdAsync(Guid playerId, CancellationToken cancellationToken)
    {
        // TODO: Implements this method
        throw new NotImplementedException("");
    }

    public Task<Player> GetPlayersAsync(CancellationToken cancellationToken)
    {
        // TODO: Implements this method
        throw new NotImplementedException();
    }
}

public class UserRepository : IUserRepository
{
    public Task<IApplicationUser> FindUserByEmailAsync(string userEmail, CancellationToken cancellationToken)
    {
        IApplicationUser p = new ApplicationUser(userEmail, "CE2813B3E59D96FE64EB74F4642029486BC308D6BCB27762196401168B9ED320:1376267DDF7328D6981F0D32C1412881:50000:SHA256", "fake user", 1, 0);
        return Task.FromResult(p);
    }
}