using Microsoft.EntityFrameworkCore;
using RoomsEnglish.Application.Data;
using RoomsEnglish.Domain.PlayerContext.Entities;

namespace RoomsEnglish.Infraestructure.Data.Context;

public class DataContext : DbContext, IApplicationDbContext
{
    public DataContext(DbContextOptions<DataContext> opt)
    : base(opt) { }

    public DbSet<ApplicationUser> Users => Set<ApplicationUser>();
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}
