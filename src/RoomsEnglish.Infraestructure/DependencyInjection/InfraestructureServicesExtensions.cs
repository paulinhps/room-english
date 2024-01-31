using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RoomsEnglish.Infraestructure.SharedContext.UseCases.Behavior;

namespace RoomsEnglish.Infraestructure.DependencyInjection;

public static class InfraestructureServicesExtensions
{
    public static IServiceCollection AddInfraestructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddPersistenceServices(configuration);

        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssemblies(AssemblyInfo.Assembly);

            cfg.AddOpenBehavior(typeof(ValidationApplicationRequestBehavior<,>));

        });

        services.AddApplicationServices();
        return services;
    }
}
