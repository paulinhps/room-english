
using Microsoft.EntityFrameworkCore;

using RoomsEnglish.Domain.PlayerContext.Entities;

namespace RoomsEnglish.Application.Data;

public interface IApplicationDbContext
{
    DbSet<Player> Users { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}