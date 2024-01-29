using RoomsEnglish.Application.Data;
using RoomsEnglish.Domain.AccountContext.Repositories;
using RoomsEnglish.Domain.UserContext.Entities;

namespace RoomsEnglish.Infraestructure.AccountContext.Repositories;

public class PlayerRepository : IPlayerRepository
{
    private readonly IApplicationDbContext _context;

    public PlayerRepository(IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<ApplicationUser> CreatePlayer(ApplicationUser user)
    {
       var result = await _context.Users.AddAsync(user);

       return result.Entity;
    }

    public Task<bool> ExistsPlayerWithEmail(string email)
    {
        throw new NotImplementedException();
    }

    public Task<Player> FindPlayerById(Guid playerId, CancellationToken cancellationToken)
    {
        // TODO: Implements this method
        throw new NotImplementedException("");
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