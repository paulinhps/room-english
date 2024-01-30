using System.Reflection;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using RoomsEnglish.Domain.AccountContext.Services;
using RoomsEnglish.Infraestructure.PlayerContext.Services;

namespace RoomsEnglish.Infraestructure.DependencyInjection;

public static class ApplicationServicesExtensions {
  public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        
        services.AddFluentValidationAutoValidation();
        services.AddFluentValidationClientsideAdapters();
        services.AddAutoMapper(Assembly.GetExecutingAssembly(), AssemblyInfo.Assembly);

        services.AddSingleton<ISecurityService, SecurityService>();
        services.AddScoped<INotificationContext, NotificationContext>();

        return services;
    }
}
