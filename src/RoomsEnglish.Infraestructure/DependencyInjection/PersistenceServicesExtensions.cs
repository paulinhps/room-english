using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RoomsEnglish.Application.Data;
using RoomsEnglish.Domain.PlayerContext.Repositories;
using RoomsEnglish.Infraestructure.Data.Context;
using RoomsEnglish.Infraestructure.PlayerContext.Repositories;

namespace RoomsEnglish.Infraestructure.DependencyInjection;

public static class PersistenceServicesExtensions {
    public static void AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDataContext>(opt =>
            opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped<IApplicationDbContext>(
            provider => provider.GetRequiredService<ApplicationDataContext>());

        services.AddRepositories();
    }

    private static IServiceCollection AddRepositories(this IServiceCollection services)
    {

        services.AddScoped<IPlayerRepository, PlayerRepository>();

        return services;
    }
}