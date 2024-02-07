using Microsoft.EntityFrameworkCore;

using RoomsEnglish.Application.Data;
using RoomsEnglish.Domain.PlayerContext.Entities;

namespace RoomsEnglish.Infraestructure.Data.Context;

public class ApplicationDataContext : DbContext, IApplicationDbContext
{
    public ApplicationDataContext(DbContextOptions<ApplicationDataContext> opt)
    : base(opt) { }

    public DbSet<Player> Users => Set<Player>();
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDataContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}
