using System;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Catalogo.Application.DependencyInjection;

public static class UseCasesConfiguration
{
    public static IServiceCollection AddUseCases(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        return services;
    }
}
