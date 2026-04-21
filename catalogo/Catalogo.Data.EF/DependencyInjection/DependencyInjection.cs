using System;
using Catalogo.Domain.Interface.Repository;
using Catalogo.Data.EF.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Catalogo.Data.EF.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddDataEF(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<ICategoriaRepository, CategoriaRepository>();
        services.AddScoped<IGeneroRepository, GeneroRepository>();
        services.AddScoped<IGeneroCategoriaRepository, GeneroCategoriaRepository>();
        services.AddDbContext<CatalogoDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("CatalogoDb")));
        return services;
    }
}
