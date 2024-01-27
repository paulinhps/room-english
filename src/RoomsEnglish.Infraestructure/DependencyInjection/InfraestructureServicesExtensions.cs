using System.Reflection;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using RoomsEnglish.Domain.AccountContext.Repositories;
using RoomsEnglish.Domain.AccountContext.Services;
using RoomsEnglish.Infraestructure.AccountContext.Repositories;
using RoomsEnglish.Infraestructure.PlayerContext.Services;
using RoomsEnglish.Infraestructure.SharedContext.UseCases.Behavior;

namespace RoomsEnglish.Infraestructure.DependencyInjection;

public static class InfraestructureServicesExtensions
{
    public static IServiceCollection AddInfraestructureServices(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssemblies(AssemblyInfo.Assembly);

            cfg.AddOpenBehavior(typeof(ValidatonCommandBehavior<,>));

        });

        services.AddFluentValidationAutoValidation();
        services.AddFluentValidationClientsideAdapters();
        services.AddAutoMapper(Assembly.GetExecutingAssembly(), AssemblyInfo.Assembly);

        services.AddRepositories();
        services.AddApplicationServices();
        return services;
    }

    private static IServiceCollection AddRepositories(this IServiceCollection services) {

        services.AddScoped<IPlayerRepository, PlayerRepository>();
        services.AddScoped<IUserRepository, UserRepository>();

        return services;
    }

    private static IServiceCollection AddApplicationServices(this IServiceCollection services) {
        
        services.AddSingleton<ISecurityService, SecurityService>();
        
        return services;
    }

}