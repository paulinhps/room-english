
using Microsoft.EntityFrameworkCore;
using RoomsEnglish.Domain.UserContext.Entities;

namespace RoomsEnglish.Application.Data;

public interface IApplicationDbContext
{
    DbSet<ApplicationUser> Users {get;}
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}