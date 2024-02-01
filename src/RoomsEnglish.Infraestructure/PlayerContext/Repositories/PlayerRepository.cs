using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using RoomsEnglish.Application.Data;
using RoomsEnglish.Domain.SharedContext.ValueObjects;
using RoomsEnglish.Domain.PlayerContext.Entities;
using RoomsEnglish.Domain.PlayerContext.Repositories;

namespace RoomsEnglish.Infraestructure.PlayerContext.Repositories;

public class PlayerRepository : IPlayerRepository
{
    private readonly IApplicationDbContext _context;

    public PlayerRepository(IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<Player> CreatePlayerAsync(Player user)
    {
        var result = await _context.Users.AddAsync(user);

        return result.Entity;
    }

    public async Task<bool> ExistsPlayerWithEmailAsync(string email)
    => await _context.Users.AsNoTracking()
        .AnyAsync(PlayerQueries.FindPlayerByEmail(email));

    public async Task<Player?> FindPlayerByIdAsync(Guid playerId, CancellationToken cancellationToken)
    => await _context.Users
        .FirstOrDefaultAsync(PlayerQueries.FindPlayerById(playerId), cancellationToken);

    public async Task<IApplicationUser?> FindPlayerByEmailAsync(string userEmail, CancellationToken cancellationToken)
    => await _context.Users
        .FirstOrDefaultAsync(PlayerQueries.FindPlayerByEmail(userEmail), cancellationToken);

    public Task<Player> GetPlayersAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
    
}

public static class PlayerQueries
{
    public static Expression<Func<Player, bool>> FindPlayerByEmail(Email userEmail)
    => player => player.Email.Equals(userEmail);

    public static Expression<Func<Player, bool>> FindPlayerById(Guid playerId)
    => player => player.Id == playerId;

}
