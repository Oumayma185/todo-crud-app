using System.Reflection;
using FluentValidation;
using gestionTaches.Application.Behaviors;
using gestionTaches.Application.Mappings;
using Mapster;
using Microsoft.Extensions.DependencyInjection;

namespace gestionTaches.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(cf =>
        {
            cf.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            
            cf.AddOpenBehavior(typeof(ValidationBehavior<,>));
        });
           
        MappingConfig.Configure();
        var config = TypeAdapterConfig.GlobalSettings;
        config.Scan(Assembly.GetExecutingAssembly());
        services.AddSingleton(config);
        
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        return services;
    }
}