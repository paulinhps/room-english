using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using RoomsEnglish.Application.Data;
using RoomsEnglish.Domain.AccountContext.Repositories;
using RoomsEnglish.Domain.SharedContext.ValueObjects;
using RoomsEnglish.Domain.UserContext.Entities;

namespace RoomsEnglish.Infraestructure.AccountContext.Repositories;

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

    public async Task<IApplicationUser?> FindPlayerByEmailAsync(string email, CancellationToken cancellationToken)
    => await _context.Users
        .FirstOrDefaultAsync(PlayerQueries.FindPlayerByEmail(email), cancellationToken);

}

public static class PlayerQueries
{
    public static Expression<Func<Player, bool>> FindPlayerByEmail(string userEmail)
    => player => player.Email.Equals((Email)userEmail);

    public static Expression<Func<Player, bool>> FindPlayerById(Guid playerId)
    => player => player.Id == playerId;

}
